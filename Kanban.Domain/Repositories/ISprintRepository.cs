using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public interface ISprintRepository
    {
        Task<Sprint> Get(int id);
        Task<IEnumerable<Sprint>> Get();
        Task Create(Sprint sprint);
        Task Remove(int id);
        Task AddBacklogItem(int backlogItemId, int sprintId);
        Task RemoveBacklogItem(int backlogItemId, int sprintId);
        Task Update(Sprint sprint);
    }
}
