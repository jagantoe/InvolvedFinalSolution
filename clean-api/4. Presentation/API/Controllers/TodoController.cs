using Business;
using Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController(TodoService todoService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var todos = await todoService.SearchTodos(null, null);
        return Ok(todos);
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> Search([FromQuery] string? title, [FromQuery] string? assignee)
    {
        var todos = await todoService.SearchTodos(title, assignee);
        return Ok(todos);
    }
    
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var todo = await todoService.GetTodoById(id);
        if (todo == null) return NotFound();
        return Ok(todo);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Add([FromBody] TodoDto todoDto)
    {
        var todo = await todoService.AddTodo(todoDto);
        return Ok(todo);
    }
    
    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] TodoDto todoDto)
    {
        var deleted = await todoService.UpdateTodo(todoDto);
        return deleted ? Ok() : NotFound();
    }
    
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await todoService.DeleteTodo(id);
        return deleted ? Ok() : NotFound();
    }
}