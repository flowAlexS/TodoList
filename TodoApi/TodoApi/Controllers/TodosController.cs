using Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
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

            return Ok(todos);
        }
    }
}
