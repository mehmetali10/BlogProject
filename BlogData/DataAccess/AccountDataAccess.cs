using BlogData.Entity;
using BlogData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogData.DataAccess
{
    public class AccountDataAccess
    {
        public static bool CreateAccount(SignUpDto signUpDto)
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            User user = new User
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                UserName = signUpDto.UserName,
                Password = signUpDto.Password
            };

            if(blogDbContext.Users.FirstOrDefault(u => u.UserName == user.UserName) != null)
            {
                return false;
            }

            blogDbContext.Users.Add(user);
            blogDbContext.SaveChanges();
            return true;
        }

        public static User Login(LoginDto loginDto)
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            User user = blogDbContext.Users.FirstOrDefault(u => u.UserName == loginDto.UserName && u.Password == loginDto.Password);

            if (user == null)
                return null;

            return user;
        }

    }
}
