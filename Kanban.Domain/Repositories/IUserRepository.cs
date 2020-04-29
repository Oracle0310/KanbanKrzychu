using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(int id);
        Task<IEnumerable<User>> Get();
        Task Create(User user);
        Task Delete(int id);
        Task Update(User user);
    }
}
