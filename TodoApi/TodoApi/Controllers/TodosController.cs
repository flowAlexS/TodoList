using Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs.Todo;
using TodoApi.Interfaces;
using TodoApi.Mappers;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITodosRepository _todosRepository;

        public TodosController(UserManager<AppUser> userManager, ITodosRepository todosRepository)
        {
            this._userManager = userManager;
            this._todosRepository = todosRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);
            
            if (appUser is null)
                return BadRequest("User Not Found");

            var todos = await this._todosRepository.GetAllAsync(appUser);

            var dtos = todos.Select(task => task.ToDto());
            return Ok(dtos);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);

            if (appUser is null)
                return BadRequest("User Not Found");

            var todo = await this._todosRepository.GetByIdAsync(appUser, id);

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo.ToDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTodoTask([FromBody] CreateTodoTaskDtoRequest createTodoTaskDtoRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);

            if (appUser is null)
                return NotFound();

            var todo = createTodoTaskDtoRequest.ToTodoTask();
            await this._todosRepository.CreateAsync(appUser, todo);

            return Ok(todo.ToDto());
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateTodoTask(
            [FromRoute] int id,
            [FromBody] UpdateTodoTaskDto updateTodoTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);

            if (appUser is null)
                return NotFound();


            var task = await this._todosRepository.GetByIdAsync(appUser, id);
            if (task is null)
                return NotFound();

            var result = await this._todosRepository.UpdateTaskAsync(task, updateTodoTaskDto.ToTodoTask());

            return result is null
                ? NotFound()
                : Ok(result.ToDto());
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var username = User.GetUsername();
            var appUser = await this._userManager.FindByNameAsync(username);

            if (appUser is null)
                return NotFound();


            var task = await this._todosRepository.GetByIdAsync(appUser, id);
            if (task is null)
                return NotFound();

            await this._todosRepository.DeleteAsync(task);
            return NoContent();
        }
    }
}
