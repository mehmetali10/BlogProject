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
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            int? userId = HttpContext.Session.GetInt32("Id");
            ViewBag.List = ArticleDataAccess.GetArticlesByUserId(userId);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Deneme(NewArticleDto newArticleDto)
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            await ArticleDataAccess.AddArticle(newArticleDto, userId);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult AddNewBlog()
        {
            ViewBag.Name = HttpContext.Session.GetString("FirstName");
            return View();
        }

        [HttpGet]
        public IActionResult ShowArticle(int articleId)
        {
            ViewBag.Article = ArticleDataAccess.GetArticleById(articleId);
            return View();
        }
    }
}
