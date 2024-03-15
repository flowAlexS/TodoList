using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TodosRepository : ITodosRepository
    {
        private readonly ApplicationDBContext _context;

        public TodosRepository(ApplicationDBContext context)
        => this._context = context;

        public async Task<TodoTask> CreateAsync(AppUser user, TodoTask task)
        {
            task.UserId = user.Id;
            task.User = user;

            await this._context.Tasks.AddAsync(task);
            await this._context.SaveChangesAsync();
            return task;
        }

        public async Task<List<TodoTask>> GetAllAsync(AppUser user)
        => await this._context.Tasks.Where(x => x.UserId.Equals(user.Id))
        .Select(task => new TodoTask()
        {
            Id = task.Id,
            Title = task.Title,
            Note = task.Note,
            Completed = task.Completed,
            User = task.User,
            UserId = task.UserId,
        }).ToListAsync();

        public async Task<TodoTask?> GetByIdAsync(AppUser user, int id)
        => await this._context.Tasks.FirstOrDefaultAsync(
            task => task.UserId.Equals(user.Id)
            && task.Id.Equals(id));

        public async Task<TodoTask> UpdateTaskAsync(TodoTask task, TodoTask updatedTask)
        {
            task.Title = updatedTask.Title;
            task.Note = updatedTask.Note;
            task.Completed = updatedTask.Completed;

            await this._context.SaveChangesAsync();
            return task;
        }
    }
}
