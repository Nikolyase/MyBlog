using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class GetArticlesResponse
    {
        public int ArticleAmount { get; set; }
        public ArticleView[] Articles { get; set; }
    }
}
