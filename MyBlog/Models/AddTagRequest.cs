using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    /// <summary>
    /// Добавляет тег
    /// </summary>
    public class AddTagRequest
    {
        public int Id { get; set; }

        public string TagText { get; set; }
    }
}
