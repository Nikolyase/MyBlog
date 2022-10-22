using MyBlog.Data.Queries;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Data.Repository
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Tag в базе 
    /// </summary>
    public interface ITagRepository
    {
        Task<Tag[]> GetTags();
        Task<Tag> GetTagById(int id);
        Task SaveTag(Tag tag);
        Task UpdateTag(Tag tag);
        Task DeleteTag(Tag tag);
    }
}
