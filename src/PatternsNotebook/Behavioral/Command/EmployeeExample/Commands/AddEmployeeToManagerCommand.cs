using PatternsNotebook.Behavioral.Command.EmployeeExample.Models;

namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Commands;

public class AddEmployeeToManagerCommand: ICommand
{
    private readonly IEmployeeManagerRepository _employeeManagerRepository;
    private readonly string _managerId;
    private readonly Employee? _employee;

    public AddEmployeeToManagerCommand(IEmployeeManagerRepository employeeManagerRepository, string managerId, Employee? employee)
    {
        _employeeManagerRepository = employeeManagerRepository;
        _managerId = managerId;
        _employee = employee;
    }

    public void Execute()
    {
        if (_employee is null)
        {
            return;
        }
        _employeeManagerRepository.AddEmployee(_managerId, _employee);
    }

    public bool CanExecute()
    {
        return _employee is not null && !_employeeManagerRepository.HasEmployee(_managerId, _employee.Id);
    }

    public void Undo()
    {
        if (_employee is null)
        {
            return;
        }
        _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
    }
}