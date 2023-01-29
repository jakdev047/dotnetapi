using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Context;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase {

        // db
        ApplicationDbContext _dbContext;

        // controller
        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // landing data
        [HttpGet]
        public List<Post>GetAll()
        {
            var posts = _dbContext.Posts.ToList();

            return posts;
        }

        // create data
        [HttpPost]
        public Post Add(Post post)
        {
            post.CreatedDate = DateTime.Now;

            _dbContext.Posts.Add(post);

            bool isSaved = _dbContext.SaveChanges() > 0;

            if(isSaved) {
                return post;
            }
            return null;
        }
    }
}
