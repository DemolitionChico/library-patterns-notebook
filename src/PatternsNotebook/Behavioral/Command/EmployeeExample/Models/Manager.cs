namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Models;

public class Manager : Employee
{
    private readonly List<Employee> _employees = new ();
    
    public Manager(string id, string name) : base(id, name)
    {
    }

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        _employees.Remove(employee);
    }

    public bool HasEmployee(string employeeId)
    {
        return _employees.Any(x => x.Id == employeeId);
    }
}