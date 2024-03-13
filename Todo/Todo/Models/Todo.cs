using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Note { get; set; }

        public bool Completed { get; set; }

        public int OwnerId { get; set; }

        public Owner? Owner { get; set; }

        public ICollection<Todo>? Todos { get; set; }    
    }
}
