using MyBlog.Data.Queries;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Data.Repository
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Comment в базе 
    /// </summary>
    public interface ICommentRepository
    {
        Task<Comment[]> GetComments();
        Task<Comment[]> GetCommentByUserId(string userId);
        Task<Comment> GetCommentById(int id);
        Task SaveComment(Comment comment, User user, Article article);
        Task UpdateComment(Comment comment, Article article);
        Task DeleteComment(Comment comment);
    }
}
