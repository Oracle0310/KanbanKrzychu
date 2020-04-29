using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public interface IItemTaskRepository
    {
        Task<ItemTask> Get(int id);
        Task<IEnumerable<ItemTask>> Get();
        Task Update(ItemTask task);
        Task AddUserToTask(int userId, int taskId);
    }
}
