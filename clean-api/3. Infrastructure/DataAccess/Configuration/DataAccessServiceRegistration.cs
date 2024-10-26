using Contracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Configuration;

public static class DataAccessServiceRegistration
{
    public static void RegisterSqliteDataAccessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        serviceCollection.AddSqlite<TodoDbContext>(connectionString);

        serviceCollection.AddScoped<IParentTodoRepository, ParentTodoRepository>();
    }
    
    public static void RegisterSqlServerDataAccessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        serviceCollection.AddSqlServer<TodoDbContext>(connectionString);

        serviceCollection.AddScoped<IParentTodoRepository, ParentTodoRepository>();
    }
}