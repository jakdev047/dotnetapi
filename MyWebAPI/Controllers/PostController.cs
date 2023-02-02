using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using MyWebAPI.Context;
using MyWebAPI.Interfaces.Manager;
//using MyWebAPI.Manager;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase {

        // db
        //ApplicationDbContext _dbContext;

        // manager
        //PostManager _postManager;

        // controller
        //public PostController(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _postManager = new PostManager(dbContext);
        //}

        // interface
        IPostManager _postManager;

        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        // landing data
        [HttpGet]
        public List<Post>GetAll()
        {
            //var posts = _dbContext.Posts.ToList();
            var posts = _postManager.GetAll().ToList();

            return posts;
        }

        // get by Id
        [HttpGet("id")]
        public Post GetById(int id)
        {
            var post = _postManager.GetById(id);

            return post;
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

        // edit 
        [HttpPut]
        public Post Edit(Post post) {

            if(post.Id == 0) {
                return null;
            }

            bool isUpdate = _postManager.Update(post);

            if(isUpdate) {

                return post;
            }

                return post;
        }

        // delete
        [HttpDelete("id")]
        public string Delete(int id)
        {
            var post = _postManager.GetById(id);

            if(post == null)
            {
                return "Data not found!";
            }

            bool isDelete = _postManager.Delete(post);

            if(isDelete)
            {
                return "post has been deleted";
            }

            return "post delete failed";
        }
    }
}
