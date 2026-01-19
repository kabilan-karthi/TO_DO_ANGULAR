using TaskManager.Api.Models.DTOs;

namespace TaskManager.Api.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskResponseDto> GetAllTasks();

        TaskResponseDto CreateTask(CreateTaskDto createTaskDto);

        bool UpdateTaskStatus(int id, string status);

        bool DeleteTask(int id);

    }
}
