using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Tag 
    {
        public int Id { get; set; }

        public string TagName { get; set; }
    }
}
