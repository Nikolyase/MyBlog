using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    /// <summary>
    /// Добавляет комментарий
    /// </summary>
    public class AddCommentRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ArticleId { get; set; }

        public string CommentText { get; set; }
    }
}
