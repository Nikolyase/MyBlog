using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Repository;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IArticleRepository _articles;
        private IMapper _mapper;
        private ICommentRepository _comments;
        private readonly ApplicationDbContext _context;

        public CommentController(UserManager<User> userManager, IArticleRepository articles, IMapper mapper, ICommentRepository comments,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _articles = articles;
            _mapper = mapper;
            _comments = comments;
            _context = context;
        }

        /// <summary>
        /// Создание комментария
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddComment(AddCommentRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return StatusCode(400, $"Ошибка: Такого пользователя не существует. Сначала зарегистрируйтесь!");

            var article = await _articles.GetArticleById(request.ArticleId);

            if (article == null)
                return StatusCode(400, $"Ошибка: статьи с Id = '{request.ArticleId}' не существует");

            if (request.CommentText == null)
                return StatusCode(400, $"Текст комментария не должен быть пустым");

            var newComment = _mapper.Map<AddCommentRequest, Comment>(request);
            await _comments.SaveComment(newComment, user, article);

            return StatusCode(201, $"Комментарий добавлен");
        }

        /// <summary>
        /// Редактирование комментария
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] int id,
            [FromBody] EditCommentRequest request)
        {
            var article = await _articles.GetArticleById(request.ArticleId);

            if (article == null)
                return StatusCode(400, $"Ошибка: статьи с Id = '{request.ArticleId}' не существует");

            var comment = await _comments.GetCommentById(id);
            if (comment == null)
                return StatusCode(400, $"Ошибка: Комментария с идентификатором {id} не существует.");

            if (request.NewCommentText == null)
                return StatusCode(400, $"Текст комментария не должен быть пустым");

            await _comments.UpdateComment(
                comment,
                article
            );

            return StatusCode(200, $"Комментарий успешно отредактирована!");
        }

        /// <summary>
        /// Удалить комментарий
        /// </summary>
        [HttpDelete]
        [Route("")]
        public async Task DeleteComment(Comment comment)
        {
            // Удаление из базы
            var entry = _context.Entry(comment);
            if (entry.State == EntityState.Detached)
                _context.Comments.Remove(comment);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получение всех комментариев
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _comments.GetComments();

            var resp = new GetCommentsResponse
            {
                CommentAmount = comments.Length,
                Comments = _mapper.Map<Comment[], CommentView[]>(comments)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Получение комментария по идентификатору
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _comments.GetCommentById(id);

            return StatusCode(200, comment);
        }
    }
}
