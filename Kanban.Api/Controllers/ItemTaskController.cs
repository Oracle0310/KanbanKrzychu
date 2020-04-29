using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Domain.Repositories;
using Kanban.Domain.Entities;
using Kanban.Api.Models;

namespace Kanban.Api.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class ItemTaskController : ControllerBase
    {
        private readonly IItemTaskRepository _taskRepository;

        public ItemTaskController(IItemTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<ItemTask>>> GetAllTasks()
        {
            var tasks = await _taskRepository.Get();

            if (!tasks.Any())
                return NotFound("No tasks found.");
            else
                return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemTask>> GetTaskById(int id)
        {
            var user = await _taskRepository.Get(id);

            if (user == null)
                return NotFound($"Task with id: {id} not found.");
            else
                return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody]UpdateTaskRequestModel task)
        {
            await _taskRepository.Update(new ItemTask
            {
                Title = task.Title,
                Description = task.Description,
                Id = id
            });

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/user/{userId}")]
        public async Task<IActionResult> AddUserToTask(int id, int userId)
        {
            await _taskRepository.AddUserToTask(userId, id);

            return Ok();
        }
    }
}
