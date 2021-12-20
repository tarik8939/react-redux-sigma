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
        private readonly UserLogic _logic;

        public UserController(UserLogic logic)
        {
            _logic = logic;
        }
        
        // GET: api/UserControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _logic.GetById(id);
        
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
            var newUser = await _logic.Register(user);
            if (newUser != null)
            {
                return Created("Success", newUser);
            }
            return BadRequest(new { message = "User wasn't register" });
        }
        
    }
}
