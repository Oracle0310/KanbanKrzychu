using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public interface IBacklogItemRepository
    {
        Task<BacklogItem> Get(int id);
        Task<IEnumerable<BacklogItem>> Get();
        Task<IEnumerable<ItemTask>> GetTasks(int id);
        Task Create(BacklogItem backlogItem);
        Task Delete(int id);
        Task Update(BacklogItem backlogItem);
        Task AddTask(ItemTask task, int backlogItemId);
        Task RemoveTask(int taskId, int backlogItemId);
    }
}
