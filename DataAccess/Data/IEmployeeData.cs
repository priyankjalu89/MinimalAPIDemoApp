using DataAccess.Models;

namespace DataAccess.Data;
public interface IEmployeeData
{
    Task DeleteEmployee(int id);
    Task<Employee> GetEmployee(int id);
    Task<IEnumerable<Employee>> GetEmployees();
    Task InsertEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
}