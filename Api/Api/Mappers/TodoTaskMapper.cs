using Api.DTOs.Todo;
using Api.Models;

namespace Api.Mappers
{
    public static class TodoTaskMapper
    {
        public static TodoTaskDto ToTodoTaksDto(this TodoTask todoTask)
        => new TodoTaskDto()
        {
            Title = todoTask.Title,
            Note = todoTask.Note,
            Completed = todoTask.Completed,
        };

        public static TodoTask ToTodoTaskFromTaskDto(this TodoTaskDto task)
        => new ()
        {
            Title = task.Title,
            Note = task.Note,
            Completed = task.Completed,
        };
    }
}
