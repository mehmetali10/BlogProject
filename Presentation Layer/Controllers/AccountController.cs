using Microsoft.AspNetCore.Mvc;
using BlogData.Dtos;
using BlogData.DataAccess;
using BlogData.Entity;
using Microsoft.AspNetCore.Authentication;


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
            User user = AccountDataAccess.Login(loginDto);

            if (user != null)
            {
                HttpContext.Session.SetInt32("Id", user.Id);
                HttpContext.Session.SetString("FirstName", user.FirstName);
                HttpContext.Session.SetString("LastName", user.LastName);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Password", user.Password);

                var testId = HttpContext.Session.GetInt32("Id");
                var testName = HttpContext.Session.GetString("FirstName");

                return RedirectToAction("Index", "Article");
            }
            else
            {
                ViewBag.Error = "Invalid inputs. try again";
                return View();
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
            if (AccountDataAccess.CreateAccount(signUpDto))
                return RedirectToAction("Login", "Account");
            else
            {
                ViewBag.Error = "Invalid inputs. Please try again !";
                return View();
            }
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("_User", string.Empty);
            HttpContext.Session.SetInt32("Id", 0);
            HttpContext.Session.SetString("FirstName", string.Empty);
            HttpContext.Session.SetString("LastName", string.Empty);
            HttpContext.Session.SetString("Email", string.Empty);
            HttpContext.Session.SetString("Password", string.Empty);
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
        }
    }
}
