using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Comment 
    {
        public int Id { get; set; }

        public string CommentText { get; set; }
    }
}
