using TaskManager.Api.Data.Interfaces;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTOs;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: Fetch all tasks
        public IEnumerable<TaskResponseDto> GetAllTasks()
        {
            var tasks = _taskRepository.GetAll();

            return tasks.Select(task => new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status.ToString(),
                ReminderEnabled = task.ReminderEnabled
            });
        }

        // POST: Create a new task
        public TaskResponseDto CreateTask(CreateTaskDto createTaskDto)
        {
            var task = new TaskItem
            {
                Id = new Random().Next(1, int.MaxValue), // temporary ID strategy
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                DueDate = createTaskDto.DueDate,
                Status = Models.TaskStatus.ToDo, // BUSINESS RULE
                ReminderEnabled = createTaskDto.ReminderEnabled
            };

            _taskRepository.Create(task);

            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status.ToString(),
                ReminderEnabled = task.ReminderEnabled
            };
        }

        // PATCH: Update task status
        public bool UpdateTaskStatus(int id, string status)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
            {
                return false;
            }

            if (!Enum.TryParse<Models.TaskStatus>(status, true, out var newStatus))
            {
                throw new ArgumentException("Invalid task status");
            }

            task.Status = newStatus;
            _taskRepository.Update(task);
            return true;
        }

        // DELETE: Delete task
        public bool DeleteTask(int id)
        {
            return _taskRepository.Delete(id);
        }
    }
}
