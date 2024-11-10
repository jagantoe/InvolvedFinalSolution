using API.Database;
using API.DTOs;
using API.Models;

namespace API.Services;

public class TodoService
{
    private readonly TodoDbContext _todoDbContext;

    public TodoService(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
        todoDbContext.Database.EnsureCreated();
    }

    public int Add(TodoDto todoDto)
    {
        var todo = new Todo
        {
            Title = todoDto.Title,
            Assignee = todoDto.Assignee,
            Description = todoDto.Description
        };

        _todoDbContext.Todos.Add(todo);
        _todoDbContext.SaveChanges();

        return todo.Id;
    }

    public List<TodoDto> Search(string? title, string? assignee)
    {
        var todos = _todoDbContext.Todos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
            todos = todos.Where(todo => todo.Title.Contains(title));

        if (!string.IsNullOrWhiteSpace(assignee))
            todos = todos.Where(todo => todo.Title.Contains(assignee));

        var todoDtos = todos
            .Select(todo => new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Assignee = todo.Assignee,
                Description = todo.Description
            })
            .ToList();

        return todoDtos;
    }

    public TodoDto Get(int id)
    {
        var todo = _todoDbContext.Todos.Find(id);

        if (todo == null) throw new Exception("Todo not found!");

        var todoDto = new TodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Assignee = todo.Assignee,
            Description = todo.Description
        };

        return todoDto;
    }

    public List<TodoDto> GetAll()
    {
        var todoDtos = _todoDbContext.Todos
            .Select(todo => new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Assignee = todo.Assignee,
                Description = todo.Description
            })
            .ToList();

        return todoDtos;
    }

    public bool Update(TodoDto todoDto)
    {
        var todo = _todoDbContext.Todos.Find(todoDto.Id);

        if (todo == null) return false;

        todo.Title = todoDto.Title;
        todo.Assignee = todoDto.Assignee;
        todo.Description = todoDto.Description;

        _todoDbContext.Todos.Update(todo);
        _todoDbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var todo = _todoDbContext.Todos.Find(id);

        if (todo == null) return false;

        _todoDbContext.Todos.Remove(todo);
        _todoDbContext.SaveChanges();

        return true;
    }
}