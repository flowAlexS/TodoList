namespace Api.DTOs.Todo
{
    public class TodoTaskDto
    {
        public string Title { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public bool Completed { get; set; }
    }
}
