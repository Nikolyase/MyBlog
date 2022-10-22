using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    /// <summary>
    /// Запрос для редактирования комментария
    /// </summary>
    public class EditCommentRequest
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string NewCommentText { get; set; }
    }
}
