namespace TodoApi.DTOs.Todo
{
    public class UpdateTodoTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public bool Completed { get; set; }
    }
}
