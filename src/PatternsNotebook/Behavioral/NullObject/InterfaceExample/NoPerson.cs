namespace PatternsNotebook.Behavioral.NullObject.InterfaceExample;

class NoPerson : IPerson
{
    public bool IsOfAge()
    {
        return false;
    }

    public string GetName()
    {
        return "No name";
    }
}