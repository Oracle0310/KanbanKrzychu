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
    public class BacklogItemRepository : IBacklogItemRepository
    {
        private readonly KanbanDbContext _context;

        public BacklogItemRepository(KanbanDbContext context)
        {
            _context = context;
        }

        public async Task AddTask(ItemTask task, int backlogItemId)
        {
            var backlogItem = await _context.BacklogItems.Include(b => b.Tasks).FirstOrDefaultAsync(b => b.Id == backlogItemId);

            if(backlogItem == default)
                throw new Exception("Provided backlogItem id is invalid");

            backlogItem.Tasks.ToList().Add(task.ToEntity());

            await _context.SaveChangesAsync();
        }

        public async Task Create(BacklogItem backlogItem)
        {
            _context.BacklogItems.Add(backlogItem.ToEntity());

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var backlogItemToDelete = await _context.BacklogItems.FirstOrDefaultAsync(b => b.Id == id);

            if(backlogItemToDelete == default)
                throw new Exception("Provided backlogItem id is invalid");

            _context.BacklogItems.Remove(backlogItemToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<BacklogItem> Get(int id)
        {
            return (await _context.BacklogItems.FirstOrDefaultAsync(b => b.Id == id)).ToModel();
        }

        public async Task<IEnumerable<BacklogItem>> Get()
        {
            return (await _context.BacklogItems.ToListAsync()).Select(b => b.ToModel());
        }

        public async Task<IEnumerable<ItemTask>> GetTasks(int id)
        {
            return (await _context.BacklogItems.Include(b => b.Tasks).FirstOrDefaultAsync(b => b.Id == id)).Tasks
                .Select(t => t.ToModel());
        }

        public async Task RemoveTask(int taskId, int backlogItemId)
        {
            var backlogItem = await _context.BacklogItems.Include(b => b.Tasks)
                .FirstOrDefaultAsync(b => b.Id == backlogItemId);

            if (backlogItem == default)
                throw new Exception("Provided backlogItem id is invalid");
            if(!backlogItem.Tasks.Any(t => t.Id == taskId))
                throw new Exception("BacklogItem with provided id does not have task with provided id");

            var taskToRemove = backlogItem.Tasks.FirstOrDefault(task => task.Id == taskId);

            backlogItem.Tasks = backlogItem.Tasks.Except(new List<DBItemTask> { taskToRemove });

            await _context.SaveChangesAsync();
        }

        public async Task Update(BacklogItem backlogItem)
        {
            var backlogItemToUpdate = await _context.BacklogItems.FirstOrDefaultAsync(b => b.Id == backlogItem.Id);

            if(backlogItemToUpdate == default)
                throw new Exception("Provided backlogItem id is invalid");

            backlogItemToUpdate.Created = backlogItem.Created;
            backlogItemToUpdate.Description = backlogItem.Description;
            backlogItemToUpdate.Title = backlogItem.Title;
            backlogItemToUpdate.EstimatedTime = backlogItem.EstimatedTime;

            await _context.SaveChangesAsync();
        }
    }
}
