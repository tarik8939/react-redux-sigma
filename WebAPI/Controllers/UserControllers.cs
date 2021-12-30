using System.Threading.Tasks;
using BusinessLogic.DTOs;
using BusinessLogic.Logics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService service;

        public UserController(UserService _service)
        {
            service = _service;
        }
        
        // GET: api/UserControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await service.GetById(id);
        
            if (user != null)
            {
                return Ok(user);
            }
        
            return BadRequest(new { message = "Can't find user" });
        }

        // POST: api/UserController
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostUser(UserDto user)
        {
            var newUser = await service.Register(user);
            if (newUser != null)
            {
                return Created("Success", newUser);
            }
            return BadRequest(new { message = "User wasn't register" });
        }
        
    }
}
