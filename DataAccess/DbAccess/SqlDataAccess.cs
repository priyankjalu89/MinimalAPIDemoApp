using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
	private readonly IConfiguration _config;

	public SqlDataAccess(IConfiguration config)
	{
		_config = config;
	}

	public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, string connectionId = "Employeedb")
	{
		using (IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId)))
		{
			var results = await connection.QueryAsync<T>(sql, parameters);
			return results;
		}
	}

	public async Task SaveData<T>(string sql, T parameters, string connectionId = "Employeedb")
	{
		using (IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId)))
		{
			await connection.ExecuteAsync(sql, parameters);
		}
	}
}
