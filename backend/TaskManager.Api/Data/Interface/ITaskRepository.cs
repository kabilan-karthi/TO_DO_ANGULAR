using TaskManager.Api.Models;

namespace TaskManager.Api.Data.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        TaskItem Create(TaskItem task);
        void Update(TaskItem task);

        bool Delete(int id); // ✅ ADD THIS
    }
}
