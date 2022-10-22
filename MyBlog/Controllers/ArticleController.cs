using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Queries;
using MyBlog.Data.Repository;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class ArticleController : Controller
    {
        private IMapper _mapper;
        private IArticleRepository _articles;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public ArticleController(IMapper mapper, IArticleRepository articles, UserManager<User> userManager, ApplicationDbContext context)
        {
            _mapper = mapper;
            _articles = articles;
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// Создание статьи
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddArticle(AddArticleRequest request)
        {
            //надо проверять что в рамках авторизованного пользователя добавляется статья
            //дату статьи в базу надо сохранять (текущую)

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return StatusCode(400, $"Ошибка: Такого пользователя не существует. Сначала зарегистрируйтесь!");

            if (request.Title == null)
                return StatusCode(400, $"Необходимо указать название статьи");

            if (request.Text == null)
                return StatusCode(400, $"Текст статьи не должен быть пустым");

            var newArticle = _mapper.Map<AddArticleRequest, Article>(request);
            await _articles.SaveArticle(newArticle, user);

            return StatusCode(201, $"Статья {request.Title} добавлена. Идентификатор: {newArticle.Id}");
        }


        /// <summary>
        /// Редактирование статьи
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] int id,
            [FromBody] EditArticleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return StatusCode(400, $"Ошибка: Такого пользователя не существует. Сначала зарегистрируйтесь!");

            var article = await _articles.GetArticleById(id);
            if (article == null)
                return StatusCode(400, $"Ошибка: Статьи с идентификатором {id} не существует.");

            if (request.NewTitle == null)
                return StatusCode(400, $"Необходимо указать название статьи");

            if (request.NewText == null)
                return StatusCode(400, $"Текст статьи не должен быть пустым");

            await _articles.UpdateArticle(
                article,
                user,
                new UpdateArticleQuery(request.NewTitle, request.NewText)
            );

            return StatusCode(200, $"Статья {request.NewTitle} успешно отредактирована!");
        }

        /// <summary>
        /// Удалить статью
        /// </summary>
        [HttpDelete]
        [Route("")]
        public async Task DeleteArticle(Article article)
        {
            // Удаление из базы
            var entry = _context.Entry(article);
            if (entry.State == EntityState.Detached)
                _context.Articles.Remove(article);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Просмотр всех статьей
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articles.GetArticles();

            var resp = new GetArticlesResponse
            {
                ArticleAmount = articles.Length,
                Articles = _mapper.Map<Article[], ArticleView[]>(articles)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Просмотр всех статьей пользователя
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllArticlesByUserId(User user)
        {
            var articles = await _articles.GetArticleByUserId(user.Id);

            var resp = new GetArticlesResponse
            {
                ArticleAmount = articles.Length,
                Articles = _mapper.Map<Article[], ArticleView[]>(articles)
            };

            return StatusCode(200, resp);
        }
    }
}
