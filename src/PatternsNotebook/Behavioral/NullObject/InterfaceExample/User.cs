namespace PatternsNotebook.Behavioral.NullObject.InterfaceExample;

class User : IPerson
{
    private readonly string _name;
    private readonly int _age;
    
    public User(string name, int age)
    {
        _name = name.ToUpper();
        _age = age;
    }
    
    public bool IsOfAge()
    {
        return _age >= 18;
    }

    public string GetName()
    {
        return _name;
    }
}