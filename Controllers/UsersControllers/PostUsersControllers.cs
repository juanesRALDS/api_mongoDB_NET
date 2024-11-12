using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoApiDemo.Services;

namespace MongoApiDemo.Controllers.UsersControllers


{
    [ApiController]
    [Route("api/users")]
    public class PostUsersControllers : ControllerBase
    {
        private readonly UserServices _userService;

        public PostUsersControllers(UserServices userService)
        {
            _userService = userService;

        }
        public async Task<ActionResult<List<Users>>> Get()
        {
            List<Users>? users = await _userService.GetAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Users newUser)
        {
            await _userService.CreateAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }
    }
}