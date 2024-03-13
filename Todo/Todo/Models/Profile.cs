namespace Todo.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
