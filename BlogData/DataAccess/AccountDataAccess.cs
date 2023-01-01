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
            if (string.IsNullOrEmpty(signUpDto.FirstName) || string.IsNullOrEmpty(signUpDto.LastName) || string.IsNullOrEmpty(signUpDto.Email) || string.IsNullOrEmpty(signUpDto.Password) )
            {
                return false;
            }

            if (!string.IsNullOrEmpty(signUpDto.Password))
            {
                if (signUpDto.Password.Length < 8)
                    return false;
            }


            BlogDbContext blogDbContext = new BlogDbContext();

            User user = new()
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                Password = signUpDto.Password
            };
         
            if(blogDbContext.Users.FirstOrDefault(u => u.Email == user.Email) != null)
            {
                return false;
            }

            blogDbContext.Users.Add(user);
            blogDbContext.SaveChanges();
            return true;
        }

        public static User? Login(LoginDto loginDto)
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            User user = blogDbContext.Users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (user == null)
                return null;

            return user;
        }

    }
}
