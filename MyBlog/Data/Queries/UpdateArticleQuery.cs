using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при редатировании статьи
    /// </summary>
    public class UpdateArticleQuery
    {
        public string NewTitle { get; }
        public string NewText { get; }

        public UpdateArticleQuery(string newTitle = null, string newText = null)
        {
            NewTitle = newTitle;
            NewText = newText;
        }
    }
}
