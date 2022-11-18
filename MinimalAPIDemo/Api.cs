namespace MinimalAPIDemo;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Employees", GetEmployees);
        app.MapGet("/Employees/{id}", GetEmployee);
        app.MapPost("/Employees", InsertEmployee);
        app.MapPut("/Employees", UpdateEmployee);
        app.MapDelete("/Employees", DeleteEmployee);
    }

    private static async Task<IResult> GetEmployees(IEmployeeData data)
    {
        try
        {
            return Results.Ok(await data.GetEmployees());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetEmployee(int id, IEmployeeData data)
    {
        try
        {
            var result = await data.GetEmployee(id);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertEmployee(Employee employee, IEmployeeData data)
    {
        try
        {
            await data.InsertEmployee(employee);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateEmployee(Employee employee, IEmployeeData data)
    {
        try
        {
            await data.UpdateEmployee(employee);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteEmployee(int id, IEmployeeData data)
    {
        try
        {
            await data.DeleteEmployee(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
