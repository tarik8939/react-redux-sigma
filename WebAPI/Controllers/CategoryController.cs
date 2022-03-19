using System.Threading.Tasks;
using BusinessLogic.Logics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService service;

        public CategoryController(CategoryService _service)
        {
            service = _service;
        }
        // GET: api/posts
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var categories = await service.GetAll();
            if (categories !=null)
            {
                return Ok(categories);
            }
            return BadRequest(new { message = "Can't find categories" });
        }
    }
}