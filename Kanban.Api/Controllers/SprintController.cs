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
    [Route("sprints")]
    public class SprintController : ControllerBase
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintController(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Sprint>>> GetAllSprints()
        {
            var sprints = await _sprintRepository.Get();

            if (!sprints.Any())
                return NotFound("No sprints found.");
            else
                return Ok(sprints);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetSprintById(int id)
        {
            var sprint = await _sprintRepository.Get(id);

            if (sprint == null)
                return NotFound($"Sprint with id: {id} not found.");
            else
                return Ok(sprint);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateNewSprint([FromBody]AddSprintRequestModel sprint)
        {
            await _sprintRepository.Create(new Sprint
            {
                StartDate = sprint.StartDate,
                AdditionalInformation = sprint.AdditionalInformation,
                EndDate = sprint.EndDate,
                SprintGoal = sprint.SprintGoal
            });

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSprint(int id)
        {
            await _sprintRepository.Remove(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSprint(int id, [FromBody]UpdateSprintRequestModel sprint)
        {
            await _sprintRepository.Update(new Sprint
            {
                Id = id,
                SprintGoal = sprint.SprintGoal,
                StartDate = sprint.StartDate,
                EndDate = sprint.EndDate,
                AdditionalInformation = sprint.AdditionalInformation
            });

            return Ok();
        }

        [HttpPost]
        [Route("{id}/backlogItem/{backlogItemId}")]
        public async Task<IActionResult> AddBacklogItemToSprint(int id, int backlogItemId)
        {
            await _sprintRepository.AddBacklogItem(backlogItemId, id);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/backlogItem/{backlogItemId}")]
        public async Task<IActionResult> RemoveBacklogItemFromSprint(int id, int backlogItemId)
        {
            await _sprintRepository.RemoveBacklogItem(backlogItemId, id);

            return Ok();
        }
    }
}
