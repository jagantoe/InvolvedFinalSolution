using Domain;

namespace Contracts.Interfaces;

public interface IParentTodoRepository
{
    Task<ICollection<Todo>> Search(string? title = null, string? assignee = null);
    Task<Todo?> GetGetById(int id);
    Task<Todo> Add(Todo todo);
    Task Update(Todo todo);
    Task Delete(Todo todo);
}