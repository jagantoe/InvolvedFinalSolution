using Contracts.Interfaces;
using DataAccess.Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ParentTodoRepository(TodoDbContext dbContext) : IParentTodoRepository
{
    public async Task<ICollection<Todo>> GetAll()
    {
        return await dbContext.Todos.ToListAsync();
    }

    public async Task<Todo?> GetGetById(int id)
    {
        return await dbContext.Todos.FindAsync(id);
    }

    public async Task<Todo> Add(Todo todo)
    {
        await dbContext.AddAsync(todo);
        await dbContext.SaveChangesAsync();
        return todo;
    }

    public async Task Update(Todo todo)
    {
        dbContext.Update(todo);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Todo todo)
    {
        dbContext.Remove(todo);
        await dbContext.SaveChangesAsync();
    }
}