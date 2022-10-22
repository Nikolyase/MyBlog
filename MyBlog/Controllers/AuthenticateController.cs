using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class AuthenticateController : Controller
    {
        private IMapper _mapper;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticateController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<UserViewModel>  Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) ||
   String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            var user = _userManager.FindByNameAsync(login);
            if (user is null)
                throw new AuthenticationException("Пользователь на найден");

            var result = await _signInManager.PasswordSignInAsync(login, password, true, false);

            if (!result.Succeeded)
                throw new AuthenticationException("Неправильный логин и (или) пароль");

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
