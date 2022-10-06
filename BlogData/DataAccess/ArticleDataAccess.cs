using BlogData.Dtos;
using BlogData.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.DataAccess
{
    public class ArticleDataAccess
    {

        public static async Task<bool> AddArticle(NewArticleDto model, int? userId)
        {
            BlogDbContext blogDbContext = new BlogDbContext();

            string picPath = "";

            //header validation
            if (model.Header == null)
                model.Header = "Blog's Header";

            //fontFamily validation
            if (model.FontFamily.Equals("Font Family"))
                model.FontFamily = "'Poppins', sans-serif";

            //FontSize validation
            if (model.FontSize.Equals("Font Size"))
                model.FontSize = "16px";

            //FontColor validation
            if (model.FontColor.Equals("Font Color"))
                model.FontColor = "#191919";

            //Picture validation
            if (model.Picture != null)
                picPath = ImageWork(model.Picture);


            Article article = new()
            {
                Header = model.Header,
                Content = model.Content,
                Picture = picPath,
                FontColor = model.FontColor,
                CreatedDate = DateTime.Now,
                FontFamily = model.FontFamily,
                FontSize = model.FontSize,
                UserId = (int) userId
            };

            await blogDbContext.Articles.AddAsync(article);


            if(blogDbContext.Entry(article).State == EntityState.Added)
            {
                await blogDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }


        private static string ImageWork(IFormFile pic)
        {
            var extension = Path.GetExtension(pic.FileName);
            var imageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", imageName);
            var stream = new FileStream(location, FileMode.Create);
            pic.CopyTo(stream);

            return imageName; //fill the image property
        }
    
    
        public static List<Article> GetArticlesByUserId(int? userId)
        {
            BlogDbContext _blogDbContext = new BlogDbContext();
            var articles = _blogDbContext.Articles.Where(x => x.UserId == userId).ToList();
            
            if(articles.Count == 0)
                return null;

            return articles;
            
        }

    
        public static  GetSingleArticleDto GetArticleById(int articleId)
        {
            BlogDbContext _blogDbContext = new BlogDbContext();
            Article article =  _blogDbContext.Articles.Find(articleId);

            if (article == null)
                return null;

            GetSingleArticleDto dto = new()
            {
                Content = article.Content,
                CreatedDate = article.CreatedDate,
                FontColor = article.FontColor,
                FontFamily = article.FontFamily,
                FontSize = article.FontSize,
                Header = article.Header,
                Picture = article.Picture,
                UserId  = article.UserId,
            };

            return dto;
        }

    
    }
}
