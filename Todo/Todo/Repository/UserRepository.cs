namespace Todo.Repository
{
    using BCrypt.Net;
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

            // Hash the password here...
            user.Password = BCrypt.HashPassword(user.Password);
            this._context.Users.Add(user);
            this._context.SaveChanges();
            return true;
        }

        public User? GetUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username.Equals(username));
            if (user != null && BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }
    }
}
