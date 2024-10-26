using System.Diagnostics.CodeAnalysis;
using Contracts.DTOs;
using Contracts.Interfaces;
using Domain;

namespace Business;

public class TodoService(IParentTodoRepository todoRepository)
{
    public async Task<ICollection<TodoDto>> GetTodos()
    {
        var todos = await todoRepository.GetAll();

        var todoDtos = todos
            .Select(pt => new TodoDto
            {
                Id = pt.Id,
                Title = pt.Title,
                Description = pt.Description,
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
                Description = todo.Description,
            };

        return todoDto;
    }
    

    public async Task<TodoDto> AddTodo(TodoDto todoDto)
    {
        var todo = new Todo
        {
            Title = todoDto.Title,
            Description = todoDto.Description,
        };

        todo = await todoRepository.Add(todo);

        return new TodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
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