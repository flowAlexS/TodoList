using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.TodoDbContext
{
    public class TodoContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Todo.Models.Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\\\MSSQLLocalDB;Database=YourDatabaseName;Trusted_Connection=True;\r\n");
        }
    }
}
