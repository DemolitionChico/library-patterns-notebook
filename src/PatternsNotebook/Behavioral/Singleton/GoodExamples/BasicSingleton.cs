namespace PatternsNotebook.Behavioral.Singleton.GoodExamples;

// This implementation only leverages C# language functionalities, without any additions. Static constructors are thread safe, though this approach is not very intuitive
public sealed class BasicSingleton
{
    public static readonly string Property = "Hello world!";

    public static BasicSingleton Instance
    {
        get
        {
            return Nested._instance;
        }
    }

    // The nested class is used, because referring BasicSingleton.Property would invoke a static constructor
    private class Nested
    {
        // Tell C# compiler not to mart type as beforefieldinit by making the constructor static implicitly
        static Nested()
        {}

        internal static readonly BasicSingleton _instance = new BasicSingleton();
    }
    
    private BasicSingleton()
    {}
}