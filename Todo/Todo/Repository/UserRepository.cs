namespace Todo.Repository
{
    using Microsoft.IdentityModel.Tokens;
    using Todo.Interfaces;
    using Todo.Models;
    using Todo.Data;

    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(User user)
        {
            if (this._context.Users.Any(x => x.Username.Equals(user.Username.Trim())))
            {
                return false;
            }

            this._context.Users.Add(user);
            this._context.SaveChanges();
            return true;
        }

        public User? GetUser(string username, string password)
        => this._context.Users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
    }
}
