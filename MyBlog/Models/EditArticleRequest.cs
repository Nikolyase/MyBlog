using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    /// <summary>
    /// Запрос для редактирования статьи
    /// </summary>
    public class EditArticleRequest
    {
        public int UserId { get; set; }
        public string NewTitle { get; set; }
        public string NewText { get; set; }
    }
}
