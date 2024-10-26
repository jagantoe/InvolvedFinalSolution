using Microsoft.Extensions.DependencyInjection;

namespace Business.Configuration;

public static class TodoApplicationServiceRegistration
{
    public static void RegisterTodoApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<TodoService>();
    }
}