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
    public class GetUserController : ControllerBase
    {

        private readonly UserServices _userServices;
    
        public GetUserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            List<Users>? users = await _userServices.GetAsync();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Users>> Get(string id)
        {
            Users? user = await _userServices.GetAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            return Ok(user);
        }



    }
}