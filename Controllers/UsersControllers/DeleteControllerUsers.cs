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
    public class DeleteControllerUsers : ControllerBase
    {
        private readonly UserServices _userService;

        public DeleteControllerUsers(UserServices userService)
        {
            _userService = userService;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            Users? user = await _userService.GetAsync(id);
            if (user is null) return NotFound();

            await _userService.RemoveAsync(id);

            return NoContent();
        }
    }
}