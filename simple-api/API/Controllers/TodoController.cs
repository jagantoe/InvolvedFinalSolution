using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost("[action]")]
    public IActionResult Add([FromBody] TodoDto todoDto)
    {
       var addedTodoId = _todoService.Add(todoDto);

        return Ok(addedTodoId);
    }
    
    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var todoDtos = _todoService.GetAll();

        return Ok(todoDtos);
    }

    [HttpGet("[action]/{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var todoDto = _todoService.Get(id);

        return Ok(todoDto);
    }

    [HttpGet("[action]")]
    public IActionResult Search([FromQuery] string? title, [FromQuery] string? assignee)
    {
        var todoDtos = _todoService.Search(title, assignee);

        return Ok(todoDtos);
    }


    [HttpPut("[action]")]
    public IActionResult Update([FromBody] TodoDto todoDto)
    {
        var updated = _todoService.Update(todoDto);

        return updated ? Ok() : NotFound();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var deleted = _todoService.Delete(id);

        return deleted ? Ok() : NotFound();
    }
}