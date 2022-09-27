using BlogData.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        IActionResult Deneme(string Header, string Content, string Picture, string FontSize, string FontFamily, string FontColor)
        {
            string a = "0";
            return View();
        }

        //[HttpPost]
        //IActionResult Deneme(NewArticleDto newArticleDto)
        //{
        //    string a = "0";
        //    return View();
        //}


        [HttpGet]
        public IActionResult AddNewBlog()
        {
            ViewBag.Name = HttpContext.Session.GetString("FirstName");
            return View();
        }
    }
}
