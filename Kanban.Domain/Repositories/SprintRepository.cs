using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Database;
using Kanban.Database.Entities;
using Kanban.Domain.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Domain.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        private readonly KanbanDbContext _context;

        public SprintRepository(KanbanDbContext context)
        {
            _context = context;
        }

        public async Task AddBacklogItem(int backlogItemId, int sprintId)
        {
            var sprint = await _context.Sprints.Include(s => s.BacklogItems).FirstOrDefaultAsync(s => s.Id == sprintId);

            if(sprint == default)
                throw new Exception("Provided sprint id is invalid");

            var backlogItem = await _context.BacklogItems.FirstOrDefaultAsync(b => b.Id == backlogItemId);

            if(backlogItem == default)
                throw new Exception("Provided backlogItem id is invalid");

            sprint.BacklogItems.ToList().Add(backlogItem);

            await _context.SaveChangesAsync();
        }

        public async Task Create(Sprint sprint)
        {
            _context.Sprints.Add(sprint.ToEntity());

            await _context.SaveChangesAsync();
        }

        public async Task<Sprint> Get(int id)
        {
            return (await _context.Sprints.FirstOrDefaultAsync(sprint => sprint.Id == id)).ToModel();
        }

        public async Task<IEnumerable<Sprint>> Get()
        {
            return (await _context.Sprints.ToListAsync()).Select(sprint => sprint.ToModel());
        }

        public async Task Remove(int id)
        {
            var sprintToRemove = await _context.Sprints.FirstOrDefaultAsync(sprint => sprint.Id == id);

            if(sprintToRemove == default)
                throw new Exception("Provided sprint id is invalid");

            _context.Sprints.Remove(sprintToRemove);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveBacklogItem(int backlogItemId, int sprintId)
        {
            var sprint = await _context.Sprints.Include(s => s.BacklogItems).FirstOrDefaultAsync(s => s.Id == sprintId);

            if(sprint == default)
                throw new Exception("Provided sprint id is invalid");
            if(!sprint.BacklogItems.Any(backlogItem => backlogItem.Id == backlogItemId))
                throw new Exception("Provided sprint does not have backlogItem with provided id.");

            var backlogItemToRemove = sprint.BacklogItems.FirstOrDefault(backlogItem => backlogItem.Id == backlogItemId);

            sprint.BacklogItems = sprint.BacklogItems.Except(new List<DBBacklogItem>{backlogItemToRemove});

            await _context.SaveChangesAsync();
        }

        public async Task Update(Sprint sprint)
        {
            var sprintToUpdate = await _context.Sprints.FirstOrDefaultAsync(sprintt => sprintt.Id == sprint.Id);

            if (sprintToUpdate == default)
                throw new Exception("Provided sprint id is invalid");

            sprintToUpdate.AdditionalInformation = sprint.AdditionalInformation;
            sprintToUpdate.EndDate = sprint.EndDate;
            sprintToUpdate.StartDate = sprint.StartDate;
            sprintToUpdate.SprintGoal = sprint.SprintGoal;

            await _context.SaveChangesAsync();
        }
    }
}
