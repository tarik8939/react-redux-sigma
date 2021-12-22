using System.Collections.Generic;

namespace BusinessLogic.DTOs
{
    public class PostDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ICollection<CategoryDto> CategoryDtos { get; set; }
    }
}
