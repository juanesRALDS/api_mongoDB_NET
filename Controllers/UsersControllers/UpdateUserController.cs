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
    public class UpdateUserController : ControllerBase
    {
        private readonly UserServices _userService;

        public UpdateUserController(UserServices userService)
        {
            _userService = userService;

        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Users updatedUser)
        {
            Users? existingUser = await _userService.GetAsync(id);
            if (existingUser is null) return NotFound();

            updatedUser.Id = existingUser.Id; // Asegurarse de mantener el mismo ID
            await _userService.UpdateAsync(id, updatedUser);

            return NoContent();
        }
    }
}