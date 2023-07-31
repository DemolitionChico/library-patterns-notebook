using PatternsNotebook.DataAccess.LazyLoad.Utilities;

namespace PatternsNotebook.DataAccess.LazyLoad;

// Examples of 4 types of lazy loading

#pragma warning disable CS0649, CS8618
public class LazyLoad
{
    // 1. LAZY INITIALIZATION - only load the property when it's called with a simple getter/setter
    private readonly IProfilePictureService _profilePictureService;
    private byte[] _profilePicture;
    public byte[] LazyInitializedProfilePicture
    {
        get => _profilePicture ??= _profilePictureService.GetFor("user-id");
        set => _profilePicture = value;
    }
    // the issue with the above is that the class knows about the technical profile picture service, 
    // which in domain classes might not be intended

    // 2. VALUE HOLDER - fot getters, use a separate class that holds the technical details of loading the value
    private ValueHolder<byte[]> _profilePictureValueHolder;
    public byte[] ValueHolderProfilePicture => _profilePictureValueHolder.GetValue("user-id");
}

public class LazyLoadModel
{
    public virtual string Name { get; set; }
    public virtual byte[] ProfilePicture { get; set; }
}

class ModelProxy : LazyLoadModel
{
    private readonly IProfilePictureService _profilePictureService;
    // 3. VIRTUAL PROXY - type supposed to be returned from repositories. This class wraps the original domain model,
    // and contains technical details of retrieving some possibly costly properties
    public override byte[] ProfilePicture
    {
        get
        {
            if (base.ProfilePicture == null)
            {
                base.ProfilePicture = _profilePictureService.GetFor(Name);
            }

            return base.ProfilePicture;
        }
        set => base.ProfilePicture = value;
    }
}

// 4. GHOST OBJECT - rarely used; also an object wrapping an original domain model (here, it also utilizes a virtual proxy
// The object contains an object in a partial state. It's supposed to be returned from the repository, and the _load
// method set in the constructor can be a repo's Get(id) method
class GhostModel : ModelProxy
{
    private LoadStatus _status;
    private Func<LazyLoadModel> _load;

    public GhostModel(Func<LazyLoadModel> load)
    {
        _load = load;
        _status = LoadStatus.GHOST;
    }

    public bool IsGhost => _status == LoadStatus.GHOST;
    public bool IsLoaded => _status == LoadStatus.LOADED;

    public override string Name
    {
        get
        {
            Load();
            return base.Name;
        }
        set
        {
            Load();
            base.Name = value;
        }
    }

    private void Load()
    {
        if (IsGhost)
        {
            _status = LoadStatus.LOADING;
            var model = _load();
            // mapping loaded properties to the base class
            base.Name = model.Name;
            _status = LoadStatus.LOADED;
        }
    }

    enum LoadStatus
    {
        GHOST,
        LOADING,
        LOADED
    };
}
#pragma warning restore CS0649, CS8618