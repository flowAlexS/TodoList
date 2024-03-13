using Api.Data;
using Api.DTOs.Todo;
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

        [HttpPost]
        public IActionResult Create([FromBody] TodoTaskDto todoTaskDto)
        {
            var task = todoTaskDto.ToTodoTaskFromTaskDto();
            this._context.Add(task);
            this._context.SaveChanges();

            return CreatedAtAction(nameof(this.GetById), new { id = task.Id }, task.ToTodoTaksDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TodoTaskDto todoTaskDto)
        {
            var task = this._context.TodoTasks.FirstOrDefault(task => task.Id.Equals(id));

            if (task is null)
            {
                return NotFound();
            }

            task.Title = todoTaskDto.Title;
            task.Note = todoTaskDto.Note;
            task.Completed = todoTaskDto.Completed;

            this._context.SaveChanges();

            return Ok(task.ToTodoTaksDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var task = this._context.TodoTasks.FirstOrDefault(task => task.Id.Equals(id));

            if (task is null)
            {
                return NotFound();
            }

            this._context.Remove(task);
            this._context.SaveChanges();

            return NoContent();
        }
    }
}
