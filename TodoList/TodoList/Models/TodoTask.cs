namespace TodoList.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Note { get; set; }

        public bool Completed { get; set; }

        public int OwnerId { get; set; }

        public Owner Owner { get; set; }

        public ICollection<TodoTask> SubTasks { get; set; }
    }
}
