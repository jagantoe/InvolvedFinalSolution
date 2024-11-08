using Contracts.DTOs;
using Contracts.Interfaces;
using Domain;

namespace Business;

public class TodoService(IParentTodoRepository todoRepository)
{
    public async Task<ICollection<TodoDto>> SearchTodos(string? title, string? description)
    {
        var todos = await todoRepository.Search(title, description);

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

    public async Task<TodoDto?> GetTodoById(int id)
    {
        var todo = await todoRepository.GetGetById(id);

        if (todo == null) return null;

        var todoDto = new TodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Assignee = todo.Assignee,
            Description = todo.Description
        };

        return todoDto;
    }


    public async Task<TodoDto> AddTodo(TodoDto todoDto)
    {
        var todo = new Todo
        {
            Title = todoDto.Title,
            Assignee = todoDto.Assignee,
            Description = todoDto.Description
        };

        todo = await todoRepository.Add(todo);

        return new TodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Assignee = todo.Assignee,
            Description = todo.Description
        };
    }

    public async Task<bool> UpdateTodo(TodoDto todoDto)
    {
        var todo = await todoRepository.GetGetById(todoDto.Id);

        if (todo == null) return false;

        todo.Title = todoDto.Title;
        todo.Description = todoDto.Description;

        await todoRepository.Update(todo);

        return true;
    }

    public async Task<bool> DeleteTodo(int id)
    {
        var todo = await todoRepository.GetGetById(id);

        if (todo == null) return false;

        await todoRepository.Delete(todo);

        return true;
    }
}