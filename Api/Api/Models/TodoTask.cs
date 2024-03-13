namespace Api.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool Completed { get; set; }
    }
}
