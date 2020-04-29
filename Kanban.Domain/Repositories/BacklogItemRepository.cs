using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public class BacklogItemRepository : IBacklogItemRepository
    {
        public Task AddTask(ItemTask task, int backlogItemId)
        {
            throw new NotImplementedException();
        }

        public Task Create(BacklogItem backlogItem)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BacklogItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BacklogItem>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemTask>> GetTasks(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTask(int taskId, int backlogItemId)
        {
            throw new NotImplementedException();
        }

        public Task Update(BacklogItem backlogItem)
        {
            throw new NotImplementedException();
        }
    }
}
