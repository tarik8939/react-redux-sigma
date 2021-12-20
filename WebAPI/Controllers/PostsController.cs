using System.Threading.Tasks;
using BusinessLogic.DTOs;
using BusinessLogic.Logics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostLogic _logic;

        public PostsController(PostLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Posts/all
        [HttpGet("all")]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _logic.GetAll();
            if (post !=null)
            {
                return Ok(post);
            }
            return BadRequest(new { message = "Can't find posts" });
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPost(int id)
        {
            var post = await _logic.GetById(id);
        
            if (post != null)
            {
                return Ok(post);
            }
        
            return BadRequest(new { message = "Can't find post" });
        }
        
        // // PUT: api/Posts/edit/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutPost(int id, PostDto post)
        {
            var editedPost = await _logic.Edit(id, post);
            if (editedPost != null)
            {
                return Created("Success", editedPost);
            }
            return BadRequest(new { message = "Post wasn't edited" }); 
        }
        
        // // POST: api/Posts
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostPost(PostDto post)
        {
            var newPost = await _logic.Create(post);
            if (newPost != null)
            {
                return Created("Success", newPost);
            }
            return BadRequest(new { message = "Post wasn't created" });
        }
        
        // // DELETE: api/Posts/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _logic.Delete(id);
            var res = await _logic.GetById(id);
            if (res==null)
            {
                return Ok(new { message = "Post was deleted" });
            }
            return BadRequest(new { message = "Post wasn't deleted" });
        }
    }
}
