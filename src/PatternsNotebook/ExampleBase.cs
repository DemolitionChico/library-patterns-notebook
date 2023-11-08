namespace PatternsNotebook;

public abstract class ExampleBase
{
    public void Run()
    {
        Start();
        Execute();
        Clear();
    }

    protected abstract void Execute();

    private void Start()
    {
        Console.Clear();
    }

    private void Clear()
    {
        Console.ReadLine();
        Console.Clear();
    }
    
}