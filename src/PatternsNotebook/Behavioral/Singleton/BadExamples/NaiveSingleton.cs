namespace PatternsNotebook.Behavioral.Singleton.BadExamples;

// This naive implementation is thread unsafe - does not prevent the constructor being called multiple times by multiple threads.
public sealed class NaiveSingleton
{
    private static NaiveSingleton _instance;

    public static NaiveSingleton Instance
    {
        get { return _instance ??= new NaiveSingleton(); }
    }

    private NaiveSingleton()
    { }
}