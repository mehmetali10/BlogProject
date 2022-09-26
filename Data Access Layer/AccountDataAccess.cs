using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data_Access_Layer
{
    public class AccountDataAccess
    {
        private static readonly BlogDbContext blogDbContext;

        public AccountDataAccess(BlogDbContext blogDbContext)
        {
            blogDbContext = blogDbContext;
        }

        public static bool CreateAccount(Presentation_Layer.Dtos.SignUpDto signUpDto)
        {
            User user = new User
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                UserName = signUpDto.UserName,
                Password = signUpDto.Password
            };

            if(blogDbContext.Users.FirstOrDefault(u => u.UserName == user.UserName) != null){
                return false;
            }

            blogDbContext.Users.Add(user);
            return true;
        }
    }
}
