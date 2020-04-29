using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban.Domain.Repositories;
using Kanban.Domain.Entities;
using Kanban.Api.Models;

namespace Kanban.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userRepository.Get();

            if (!users.Any())
                return NotFound("No users found.");
            else
                return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.Get(id);

            if (user == null)
                return NotFound($"User with id: {id} not found.");
            else
                return Ok(user);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateNewUser([FromBody]User user)
        {
            await _userRepository.Create(user);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.Delete(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UpdateUserRequestModel user)
        {
            await _userRepository.Update(new User
            {
                Id = id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            });

            return Ok();
        }
    }
}
