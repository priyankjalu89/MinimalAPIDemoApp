using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class EmployeeData : IEmployeeData
{
    private readonly ISqlDataAccess _db;

    public EmployeeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Employee>> GetEmployees()
    {
        var results = _db.LoadData<Employee, dynamic>("select id,name,age,address,mobile_number as mobilenumber from public.employee", new { });
        return results;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        var results = await _db.LoadData<Employee, dynamic>("select id,name,age,address,mobile_number as mobilenumber from public.employee where id=@id", new { id });
        return results.FirstOrDefault();
    }

    public Task InsertEmployee(Employee employee)
    {
        return _db.SaveData("Insert into public.employee (name,age,address,mobile_number) values (@Name,@Age,@Address,@MobileNumber)", employee);
    }

    public Task UpdateEmployee(Employee employee)
    {
        return _db.SaveData("Update public.employee set name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber where id=@Id", employee);
    }

    public Task DeleteEmployee(int id)
    {
        return _db.SaveData("Delete from public.employee where id=@Id", new { id });
    }
}
