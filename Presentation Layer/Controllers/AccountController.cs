using Microsoft.AspNetCore.Mvc;
using BlogData.Dtos;
using BlogData.DataAccess;
using BlogData.Entity;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Presentation_Layer.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                ViewBag.Error = "Lütfen kullanıcı bilgileriniz eksiksiz doldurunuz";
                return View("Login");
            }

            User user = AccountDataAccess.Login(loginDto);

            if (user != null)
            {
                var sesion = new SesionDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(sesion))
                };
                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("_User", JsonConvert.SerializeObject(sesion));

                return View("SignUp");
            }
            else
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre..";
                return View("Login");
            }

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpDto signUpDto)
        {
            AccountDataAccess.CreateAccount(signUpDto);
            return View();
        }
    }
}
