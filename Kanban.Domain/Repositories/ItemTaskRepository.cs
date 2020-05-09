using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Database;
using Kanban.Domain.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Domain.Repositories
{
    public class ItemTaskRepository : IItemTaskRepository
    {
        private readonly KanbanDbContext _context;

        public ItemTaskRepository(KanbanDbContext context)
        {
            _context = context;
        }

        public async Task AddUserToTask(int userId, int taskId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if(user == default)
                throw new Exception("Provided user id is invalid");

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            if(task == default)
                throw new Exception("Provided task id is invalid");

            task.User = user;

            await _context.SaveChangesAsync();
        }

        public async Task<ItemTask> Get(int id)
        {
            return (await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id)).ToModel();
        }

        public async Task<IEnumerable<ItemTask>> Get()
        {
            return (await _context.Tasks.ToListAsync()).Select(t => t.ToModel());
        }

        public async Task Update(ItemTask task)
        {
            var taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);

            if(taskToUpdate == default)
                throw new Exception("Provided task id is invalid");

            taskToUpdate.Created = task.Created;
            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;

            await _context.SaveChangesAsync();
        }
    }
}
