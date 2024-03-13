namespace TodoList.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<TodoTask>? Tasks { get; set; }
    }
}
