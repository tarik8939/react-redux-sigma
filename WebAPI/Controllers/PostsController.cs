using System.Threading.Tasks;
using BusinessLogic.DTOs;
using BusinessLogic.Logics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostService service;

        public PostsController(PostService _service)
        {
            service = _service;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await service.GetAll2();
            if (post !=null)
            {
                return Ok(post);
            }
            return BadRequest(new { message = "Can't find posts" });
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPost(int id)
        {
            var post = await service.GetById2(id);
        
            if (post != null)
            {
                return Ok(post);
            }
        
            return BadRequest(new { message = "Can't find post" });
        }
        
        // GET: api/posts/user/5
        // Get all posts by userId
        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetPostByUserId(int id)
        {
            var post = await service.GetByUserId(id);
        
            if (post != null)
            {
                return Ok(post);
            }
        
            return BadRequest(new { message = "Can't find posts" });
        }
        
        // // PUT: api/posts/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDto post)
        {
            var editedPost = await service.Edit(id, post);
            if (editedPost != null)
            {
                return Created("Success", editedPost);
            }
            return BadRequest(new { message = "Post wasn't edited" }); 
        }
        
        // // POST: api/posts
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostPost(PostDto post)
        {
            var newPost = await service.Create(post);
            if (newPost != null)
            {
                return Created("Success", newPost);
            }
            return BadRequest(new { message = "Post wasn't created" });
        }
        
        // // DELETE: api/posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await service.Delete(id);
            var res = await service.GetById(id);
            if (res==null)
            {
                return Ok(new { message = "Post was deleted" });
            }
            return BadRequest(new { message = "Post wasn't deleted" });
        }
    }
}
