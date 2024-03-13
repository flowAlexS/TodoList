using Api.Data;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TodoController(ApplicationDBContext context)
        => this._context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = this._context.TodoTasks.Select(todo => todo.ToTodoTaksDto()).ToList();

            return Ok(todos);
        }
    }
}
