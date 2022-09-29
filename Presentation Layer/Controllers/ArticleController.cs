using BlogData.DataAccess;
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
        public async Task<IActionResult> Deneme(NewArticleDto newArticleDto)
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            await ArticleDataAccess.AddArticle(newArticleDto, userId);
            return View("Index");
        }



        [HttpGet]
        public IActionResult AddNewBlog()
        {
            ViewBag.Name = HttpContext.Session.GetString("FirstName");
            return View();
        }
    }
}
