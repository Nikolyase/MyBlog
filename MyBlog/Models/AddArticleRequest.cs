using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    /// <summary>
    /// Добавляет статью
    /// </summary>
    public class AddArticleRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
