namespace Todo.Interfaces
{
    using Todo.Models;

    public interface IUserRepository
    {
        bool Add(User user);

        User GetUser(string username, string password);
    }
}
