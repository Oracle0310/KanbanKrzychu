using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public class ItemTaskRepository : IItemTaskRepository
    {
        public Task AddUserToTask(int userId, int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemTask> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemTask>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(ItemTask task)
        {
            throw new NotImplementedException();
        }
    }
}
