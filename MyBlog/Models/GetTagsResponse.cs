using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class GetTagsResponse
    {
        public int TagAmount { get; set; }
        public TagView[] Tags { get; set; }
    }
}
