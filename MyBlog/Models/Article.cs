using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Article 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
