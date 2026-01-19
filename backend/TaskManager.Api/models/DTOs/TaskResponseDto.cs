using System;

namespace TaskManager.Api.Models.DTOs
{
    public class TaskResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public bool ReminderEnabled { get; set; }
    }
}
