using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Context;
using MyWebAPI.Manager;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase {

        // db
        ApplicationDbContext _dbContext;

        // manager
        PostManager _postManager;

        // controller
        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _postManager = new PostManager(dbContext);
        }

        // landing data
        [HttpGet]
        public List<Post>GetAll()
        {
            //var posts = _dbContext.Posts.ToList();
            var posts = _postManager.GetAll().ToList();

            return posts;
        }

        // create data
        [HttpPost]
        public Post Add(Post post)
        {
            post.CreatedDate = DateTime.Now;

            //_dbContext.Posts.Add(post);

            //bool isSaved = _dbContext.SaveChanges() > 0;

            bool isSaved = _postManager.Add(post);

            if(isSaved) {
                return post;
            }
            return null;
        }
    }
}
