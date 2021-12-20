using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
