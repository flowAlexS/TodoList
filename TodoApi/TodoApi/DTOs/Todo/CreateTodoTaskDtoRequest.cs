using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs.Todo
{
    public class CreateTodoTaskDtoRequest
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(20000)]
        public string Note { get; set; } = string.Empty;

        public bool Completed { get; set; }
    }
}
