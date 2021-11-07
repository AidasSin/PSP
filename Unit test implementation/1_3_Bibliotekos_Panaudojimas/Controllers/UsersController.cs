using _1_3_Bibliotekos_Panaudojimas.Entities;
using _1_3_Bibliotekos_Panaudojimas.Models;
using _1_3_Bibliotekos_Panaudojimas.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _1_3_Bibliotekos_Panaudojimas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserServiceRepository _userServiceRepository;

        public UsersController(IUserServiceRepository userServiceRepository)
        {
            _userServiceRepository = userServiceRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsersAsync(CancellationToken cancellation)
        {
            var users = await _userServiceRepository.GetAllUsersAsync(cancellation);
            return users.Select(u => u.ToModel());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellation)
        {
            var request = await _userServiceRepository.GetByIdAsync(Id, cancellation);
            if(request is null)
            {
                return NotFound();
            }
            return Ok(request.ToModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserModel user, CancellationToken cancellation)
        {
            var newUser = user.ToEntity();
            var created = await _userServiceRepository.CreateUserAsync(newUser, cancellation);
            return CreatedAtAction("GetById", new { Id = created.Id }, created.ToModel());
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id, CancellationToken cancellation)
        {
            var existing = await _userServiceRepository.GetByIdAsync(Id, cancellation);
            if (existing is null)
                return NotFound();

            await _userServiceRepository.DeleteUserAsync(Id, cancellation);
            return NoContent();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserModel user, CancellationToken cancellation)
        {
            var existing = await _userServiceRepository.GetByIdAsync(user.Id, cancellation);
            if (existing is null)
                return NotFound();

            var entity = user.ToEntity();
            await _userServiceRepository.EditUserInfoAsync(entity, cancellation);
            return Ok();
        }


    }
}
