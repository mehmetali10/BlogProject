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
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            int? userId = HttpContext.Session.GetInt32("Id");
            ViewBag.List = ArticleDataAccess.GetArticlesByUserId(userId);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewBlog(NewArticleDto newArticleDto)
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            if(await ArticleDataAccess.AddArticle(newArticleDto, userId))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Error = "Blog title and header cannot be empty";
                return View();
            }
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
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            ViewBag.Article = ArticleDataAccess.GetArticleById(articleId);
            return View();
        }
    }
}
