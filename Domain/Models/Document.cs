using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
