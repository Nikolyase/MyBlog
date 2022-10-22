using AutoMapper;
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
    public class TagController : Controller
    {
        private IMapper _mapper;
        private ITagRepository _tags;
        private readonly ApplicationDbContext _context;

        public TagController(IMapper mapper,ITagRepository tags, ApplicationDbContext context)
        {
            _mapper = mapper;
            _tags = tags;
            _context = context;
        }

        /// <summary>
        /// Создание тега
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddTag(AddTagRequest request)
        {
            if (request.TagText == null)
                return StatusCode(400, $"Тег не должен быть пустым");

            var newTag = _mapper.Map<AddTagRequest, Tag>(request);
            await _tags.SaveTag(newTag);

            return StatusCode(201, $"Тег '{request.TagText}' добавлен");
        }

        /// <summary>
        /// Редактирование тега
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] int id,
            [FromBody] EditTagRequest request)
        {
            var tag = await _tags.GetTagById(id);
            if (tag == null)
                return StatusCode(400, $"Ошибка: Тега с идентификатором {id} не существует.");

            if (request.NewTagText == null)
                return StatusCode(400, $"Тег не должен быть пустым");

            await _tags.UpdateTag(
                tag
            );

            return StatusCode(200, $"Тег успешно отредактирован!");
        }

        /// <summary>
        /// Удалить тег
        /// </summary>
        [HttpDelete]
        [Route("")]
        public async Task DeleteTag(Tag tag)
        {
            // Удаление из базы
            var entry = _context.Entry(tag);
            if (entry.State == EntityState.Detached)
                _context.Tags.Remove(tag);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получение всех тегов
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tags.GetTags();

            var resp = new GetTagsResponse
            {
                TagAmount = tags.Length,
                Tags = _mapper.Map<Tag[], TagView[]>(tags)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Получение тега по идентификатору
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var tag = await _tags.GetTagById(id);

            return StatusCode(200, tag);
        }
    }
}
