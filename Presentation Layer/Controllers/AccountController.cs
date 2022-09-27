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
                //var sesion = new SesionDto
                //{
                //    Id = user.Id,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    UserName = user.UserName,
                //    Password = user.Password
                //};

               

                HttpContext.Session.SetInt32("Id", user.Id);
                HttpContext.Session.SetString("FirstName", user.FirstName);
                HttpContext.Session.SetString("LastName", user.LastName);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("Password", user.Password);

                var testId = HttpContext.Session.GetInt32("Id");
                var testName = HttpContext.Session.GetString("FirstName");

                return RedirectToAction("Index", "Article");
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


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("_User", string.Empty);
            HttpContext.Session.SetInt32("Id", 0);
            HttpContext.Session.SetString("FirstName", string.Empty);
            HttpContext.Session.SetString("LastName", string.Empty);
            HttpContext.Session.SetString("Email", string.Empty);
            HttpContext.Session.SetString("UserName", string.Empty);
            HttpContext.Session.SetString("Password", string.Empty);
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
        }
    }
}
