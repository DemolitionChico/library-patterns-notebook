namespace PatternsNotebook.Behavioral.Singleton.GoodExamples;

// The simplest and most readable solution with both performance and thread safety solved
public sealed class LazySingleton
{
    // reading this will initialize the instance
    private static readonly Lazy<LazySingleton> _lazy = new Lazy<LazySingleton>(() => new LazySingleton());

    public static LazySingleton Instance => _lazy.Value;

    private LazySingleton()
    { }
}