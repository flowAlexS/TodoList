using TodoApi.DTOs.Todo;
using TodoApi.Models;

namespace TodoApi.Mappers
{
    public static class TodoMapper
    {
        public static TodoTaskDto ToDto(this TodoTask task)
        => new()
        {
            Id = task.Id,
            Title = task.Title,
            Note = task.Note,
            Completed = task.Completed,
        };
    }
}
