namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId = "Employeedb");
    Task SaveData<T>(string sql, T parameters, string connectionId = "Employeedb");
}