using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class UserViewModel
    {
        public string FullName { get; set; }

        public UserViewModel(User user)
        {
            FullName = user.GetFullName();
        }
    }
}
