using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Models.DTOs
{
    public class UpdateTaskStatusDto
    {
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
