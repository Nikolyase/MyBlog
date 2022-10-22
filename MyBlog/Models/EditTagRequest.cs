using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    /// <summary>
    /// Запрос для редактирования тега
    /// </summary>
    public class EditTagRequest
    {
        public string NewTagText { get; set; }
    }
}
