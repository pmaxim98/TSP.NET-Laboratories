using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCommentASP.Models
{
    public class PostDTO
    {
        public PostDTO()
        {
            this.Comments = new List<CommentDTO>();
        }

        public int PostId { get; set; }

        public string Description { get; set; }

        public string Domain { get; set; }

        public string Date { get; set; }

        public virtual List<CommentDTO> Comments { get; set; }
    }
}
