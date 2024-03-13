using Api.Data;
using Api.DTOs.Todo;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var todos = await this._context.TodoTasks.ToListAsync();

            var todosDto = todos.Select(task => task.ToTodoTaksDto());

            return Ok(todosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todo = await this._context.TodoTasks.FirstOrDefaultAsync(task => task.Id.Equals(id));

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo.ToTodoTaksDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoTaskDto todoTaskDto)
        {
            var task = todoTaskDto.ToTodoTaskFromTaskDto();
            await this._context.AddAsync(task);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(this.GetById), new { id = task.Id }, task.ToTodoTaksDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TodoTaskDto todoTaskDto)
        {
            var task = await this._context.TodoTasks.FirstOrDefaultAsync(task => task.Id.Equals(id));

            if (task is null)
            {
                return NotFound();
            }

            task.Title = todoTaskDto.Title;
            task.Note = todoTaskDto.Note;
            task.Completed = todoTaskDto.Completed;

            await this._context.SaveChangesAsync();

            return Ok(task.ToTodoTaksDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var task = await this._context.TodoTasks.FirstOrDefaultAsync(task => task.Id.Equals(id));

            if (task is null)
            {
                return NotFound();
            }

            this._context.Remove(task);
            await this._context.SaveChangesAsync();

            return NoContent();
        }
    }
}
