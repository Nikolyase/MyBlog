using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class GetCommentsResponse
    {
        public int CommentAmount { get; set; }
        public CommentView[] Comments { get; set; }
    }
}
