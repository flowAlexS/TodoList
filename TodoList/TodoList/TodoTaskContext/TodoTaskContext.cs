using TodoList.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Context
{
    public class TodoTaskContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=YourDatabaseName;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>()
                .HasOne(t => t.Owner)
                .WithMany(o => o.Tasks)
                .HasForeignKey(t => t.OwnerId);

            modelBuilder.Entity<TodoTask>()
                .HasMany(t => t.SubTasks)
                .WithOne()
                .HasForeignKey(t => t.OwnerId);
        }
    }
}
