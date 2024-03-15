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

        public static TodoTask ToTodoTask(this CreateTodoTaskDtoRequest taskDto)
        => new()
        {
            Title = taskDto.Title,
            Note = taskDto.Note,
            Completed = taskDto.Completed,
        };

        public static TodoTask ToTodoTask(this UpdateTodoTaskDto taskDto)
        => new()
        {
            Title = taskDto.Title,
            Note = taskDto.Note,
            Completed = taskDto.Completed,
        };
    }
}
