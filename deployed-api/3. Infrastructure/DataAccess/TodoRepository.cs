using Contracts.Interfaces;
using DataAccess.Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ParentTodoRepository(TodoDbContext dbContext) : IParentTodoRepository
{
    public async Task<ICollection<Todo>> Search(string? title, string? assignee)
    {
        var query = dbContext.Todos.AsQueryable();

        if (!string.IsNullOrEmpty(title))
            query = query.Where(todo => todo.Title.Contains(title));

        if (!string.IsNullOrEmpty(assignee))
            query = query.Where(todo => todo.Assignee.Contains(assignee));

        return await query.ToListAsync();
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