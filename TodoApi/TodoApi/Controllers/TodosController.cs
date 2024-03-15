using Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            var todo = await this._todosRepository.GetByIdAsync(appUser, id);

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo.ToDto());
        }
    }
}
