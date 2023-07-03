namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Models;

public class Employee
{
    public string Id { get; init; }
    public string Name { get; init; }

    public Employee(string id, string name)
    {
        Id = id;
        Name = name;
    }
}