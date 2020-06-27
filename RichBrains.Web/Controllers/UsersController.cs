using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RichBrains.Logic.Interfaces;
using RichBrains.Logic.Models;

namespace RichBrains.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<UserDto>>> GetUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var userDb = await _userService.GetByIdAsync(id);

            if (userDb == null)
            {
                return NotFound();
            }

            return Ok(userDb);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [CustomizeValidator(RuleSet = "UserPreValidation")] UserDto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userService.Update(user);

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([CustomizeValidator(RuleSet = "UserPreValidation")] UserDto user)
        {
            var createdUser = await _userService.Create(user);
            return Ok(createdUser);
        }

        // DELETE: api/Users/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(Guid id)
        {
            var userDb = await _userService.GetByIdAsync(id);
            if (userDb == null)
            {
                return NotFound();
            }

            _userService.Remove(userDb);
            return userDb;
        }
    }
}
