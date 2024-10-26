using System;
using Domain;

namespace Contracts.Interfaces;

public interface IParentTodoRepository
{
    Task<ICollection<Todo>> GetAll();
    Task<Todo?> GetGetById(int id);
    Task<Todo> Add(Todo todo);
    Task Update(Todo todo);
    Task Delete(Todo todo);
}
