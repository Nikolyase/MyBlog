using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Image { get; set; }

        public string Status { get; set; }

        public string About { get; set; }

        public List<Role> Roles { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }

        public User()
        {
            Image = "https://thispersondoesnotexist.com/image";
            Status = "Это мой блог!";
            About = "Информация обо мне.";
        }
    }
}
