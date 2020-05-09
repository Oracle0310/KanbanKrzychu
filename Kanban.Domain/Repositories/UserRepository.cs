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
    public class UserRepository : IUserRepository
    {
        private readonly KanbanDbContext _context;

        public UserRepository(KanbanDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            _context.Users.Add(user.ToEntity());

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userToRemove = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            if(userToRemove == default)
                throw new Exception("Provided user id is invalid.");

            _context.Users.Remove(userToRemove);

            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return (await _context.Users.FirstOrDefaultAsync(user => user.Id == id)).ToModel();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return (await _context.Users.ToListAsync()).Select(user => user.ToModel());
        }

        public async Task Update(User user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(user => user.Id == user.Id);

            if(userToUpdate == default)
                throw new Exception("Provided user id is invalid");

            userToUpdate.Email = user.Email;
            userToUpdate.Name = user.Name;
            userToUpdate.Surname = user.Surname;

            await _context.SaveChangesAsync();
        }
    }
}
