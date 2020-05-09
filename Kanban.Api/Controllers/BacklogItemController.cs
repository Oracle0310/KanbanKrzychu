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
    [Route("backlogItems")]
    public class BacklogItemController : ControllerBase
    {
        private readonly IBacklogItemRepository _backlogItemRepository;

        public BacklogItemController(IBacklogItemRepository backlogItemRepository)
        {
            _backlogItemRepository = backlogItemRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<BacklogItem>>> GetAllBacklogItems()
        {
            var backlogItems = await _backlogItemRepository.Get();

            if (!backlogItems.Any())
                return NotFound("No backlogItems found.");
            else
                return Ok(backlogItems);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ItemTask>> GetBacklogItemById(int id)
        {
            var user = await _backlogItemRepository.Get(id);

            if (user == null)
                return NotFound($"BacklogItem with id: {id} not found.");
            else
                return Ok(user);
        }

        [HttpGet]
        [Route("{id}/tasks")]
        public async Task<ActionResult<IEnumerable<ItemTask>>> GetBacklogItemTasks(int id)
        {
            var tasks = await _backlogItemRepository.GetTasks(id);

            if (!tasks.Any())
                return NotFound($"No tasks found for backlogItem with id: {id}.");
            else
                return Ok(tasks);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateBacklogItem([FromBody]AddBacklogItemRequestModel backlogItem)
        {
            await _backlogItemRepository.Create(new BacklogItem
            {
                EstimatedTime = backlogItem.EstimatedTime,
                Created = backlogItem.Created,
                Description = backlogItem.Description,
                Title = backlogItem.Title
            });

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBacklogItem(int id)
        {
            await _backlogItemRepository.Delete(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBacklogItem(int id, [FromBody]UpdateBacklogItemRequestModel backlogItem)
        {
            await _backlogItemRepository.Update(new BacklogItem
            {
                Title = backlogItem.Title,
                Description = backlogItem.Description,
                EstimatedTime = backlogItem.EstimatedTime,
                Id = id
            });

            return Ok();
        }

        [HttpPost]
        [Route("{id}/tasks")]
        public async Task<IActionResult> AddTaskToBacklogItem(int id, [FromBody]AddTaskRequestModel task)
        {
            await _backlogItemRepository.AddTask(new ItemTask
            {
                Created = DateTime.Now,
                Description = task.Description,
                Title = task.Title
            }, id);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/tasks/{taskId}")]
        public async Task<IActionResult> DeleteTaskFromBacklogItem(int id, int taskId)
        {
            await _backlogItemRepository.RemoveTask(taskId, id);

            return Ok();
        }
    }
}
