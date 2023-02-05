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

        // landing data  => ActionResult<List<Post>> = IActionResult
        [HttpGet]
        public IActionResult GetAll()
        {
            //var posts = _dbContext.Posts.ToList();
            var posts = _postManager.GetAll().ToList();

            return Ok(posts);
        }

        // get by Id
        [HttpGet("id")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _postManager.GetById(id);

            if(post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // create data
        [HttpPost]
        public ActionResult<Post> Add(Post post)
        {
            post.CreatedDate = DateTime.Now;

            //_dbContext.Posts.Add(post);

            //bool isSaved = _dbContext.SaveChanges() > 0;

            bool isSaved = _postManager.Add(post);

            if(isSaved) {
                return Created("", post);
            }
            return BadRequest("Post save failed");
        }

        // edit 
        [HttpPut]
        public ActionResult<Post> Edit(Post post) {

            if(post.Id == 0) {
                return BadRequest("Id is missing");
            }

            bool isUpdate = _postManager.Update(post);
              
            if(isUpdate) {

                return Ok(post);
            }

                return BadRequest("Post updated failed");
        }

        // delete
        [HttpDelete("id")]
        public ActionResult<string> Delete(int id)
        {
            var post = _postManager.GetById(id);

            if(post == null)
            {
                return NotFound();
            }

            bool isDelete = _postManager.Delete(post);

            if(isDelete)
            {
                return Ok("Post has been deleted");
            }

            return BadRequest("Post delete failed");
        }
    }
}
