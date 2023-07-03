namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Models;

public interface IEmployeeManagerRepository
{
    void AddEmployee(string managerId, Employee employee);
    void RemoveEmployee(string managerId, Employee employee);
    bool HasEmployee(string managerId, string employeeId);
}