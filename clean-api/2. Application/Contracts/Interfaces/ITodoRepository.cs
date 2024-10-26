using Domain;

namespace Contracts.Interfaces;

public interface IParentTodoRepository
{
    Task<ICollection<Todo>> Search(string? title, string? assignee);
    Task<Todo?> GetGetById(int id);
    Task<Todo> Add(Todo todo);
    Task Update(Todo todo);
    Task Delete(Todo todo);
}