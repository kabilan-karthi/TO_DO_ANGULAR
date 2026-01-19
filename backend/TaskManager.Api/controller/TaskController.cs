using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models.DTOs;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: /api/tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // POST: /api/tasks
        [HttpPost]
        public IActionResult CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTask = _taskService.CreateTask(createTaskDto);
            return CreatedAtAction(nameof(GetAllTasks), createdTask);
        }

        // PATCH: /api/tasks/{id}/status
        [HttpPatch("{id}/status")]
        public IActionResult UpdateTaskStatus(int id, [FromBody] UpdateTaskStatusDto dto)
        {
            var updated = _taskService.UpdateTaskStatus(id, dto.Status);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // ✅ DELETE: /api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var deleted = _taskService.DeleteTask(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
