using TodoApi.Models;

namespace TodoApi.Interfaces
{
    public interface ITodosRepository
    {
        Task<List<TodoTask>> GetAllAsync(AppUser user);

        Task<TodoTask?> GetByIdAsync(AppUser user, int id);
    }
}
