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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var todo = this._context.TodoTasks.FirstOrDefault(task => task.Id.Equals(id));

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo.ToTodoTaksDto());
        }
    }
}
