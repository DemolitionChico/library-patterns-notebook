namespace PatternsNotebook.Behavioral.Singleton.BadExamples;

// This implementation improves performance, as it doesn't need to be locked that often
public sealed class BetterLockedSingleton
{
    private static BetterLockedSingleton _instance;
    private static readonly object padlock = new object(); 

    public static BetterLockedSingleton Instance
    {
        get
        {
            // double check locking pattern
            if (_instance is null)
            {
                lock (padlock)
                {
                    return _instance ??= new BetterLockedSingleton();
                }   
            }
            return _instance;
        }
    }

    private BetterLockedSingleton()
    { }
}