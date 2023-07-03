namespace PatternsNotebook.Behavioral.Singleton.BadExamples;

// This implementation is thread safe, but has performance overhead, locking the instance each time it's called
public sealed class LockedSingleton
{
    #pragma warning disable CS8618
    private static LockedSingleton _instance;
    private static readonly object padlock = new object(); 

    public static LockedSingleton Instance
    {
        get
        {
            lock (padlock)
            {
                return _instance ??= new LockedSingleton();
            }
        }
    }
    
    private LockedSingleton()
    { }
    #pragma warning restore CS8618
}