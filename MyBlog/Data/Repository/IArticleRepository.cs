using MyBlog.Data.Queries;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Data.Repository
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Article в базе 
    /// </summary>
    public interface IArticleRepository
    {
        Task<Article[]> GetArticles();
        Task<Article[]> GetArticleByUserId(string userId);
        Task<Article> GetArticleById(int id);
        Task SaveArticle(Article article, User user);
        Task UpdateArticle(Article article, User user, UpdateArticleQuery query);
        Task DeleteArticle(Article article);
    }
}
