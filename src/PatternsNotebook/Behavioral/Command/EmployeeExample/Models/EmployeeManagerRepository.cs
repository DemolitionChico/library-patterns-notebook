namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Models;

public class EmployeeManagerRepository : IEmployeeManagerRepository
{
    private readonly List<Manager> _managers = new List<Manager>()
    {
        new Manager("A1", "Katie"),
        new Manager("B2", "George")
    };
    
    public void AddEmployee(string managerId, Employee employee)
    {
        _managers.First(x => x.Id == managerId).AddEmployee(employee);
    }

    public void RemoveEmployee(string managerId, Employee employee)
    {
        _managers.First(x => x.Id == managerId).RemoveEmployee(employee);
    }

    public bool HasEmployee(string managerId, string employeeId)
    {
        return _managers.First(x => x.Id == managerId).HasEmployee(employeeId);
    }
}