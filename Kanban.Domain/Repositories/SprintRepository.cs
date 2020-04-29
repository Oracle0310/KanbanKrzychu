using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        public Task AddBacklogItem(int backlogItemId, int sprintId)
        {
            throw new NotImplementedException();
        }

        public Task Create(Sprint sprint)
        {
            throw new NotImplementedException();
        }

        public Task<Sprint> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sprint>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBacklogItem(int backlogItemId, int sprintId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Sprint sprint)
        {
            throw new NotImplementedException();
        }
    }
}
