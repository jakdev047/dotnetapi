using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
//using MyWebAPI.Context;
using MyWebAPI.Interfaces.Manager;
//using MyWebAPI.Manager;
using MyWebAPI.Models;
using System.Net;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController {

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
            try
            {
                //var posts = _dbContext.Posts.ToList();
                var posts = _postManager.GetAll().OrderBy(c => c.CreatedDate).ToList();

                //return Ok(posts);

                return CustomResult("Data loaded successfully",posts, HttpStatusCode.OK);
                
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("title")]
        public IActionResult GetAll(string title)
        {
            try
            {
                var posts = _postManager.GetAll(title);

                //return Ok(posts);

                return CustomResult("Data loaded successfully", posts.ToList(), HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("text")]
        public IActionResult SearchPost(string text)
        {
            try
            {
                var posts = _postManager.SearchPost(text);

                return CustomResult("Data loaded successfully", posts.ToList(), HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetPosts(int page = 1, int pageSize = 2)
        {
            try
            {
                var posts = _postManager.GetPosts(page, pageSize);

                return CustomResult("Data loaded successfully", posts.ToList(), HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetAllDes()
        {
            try
            {
                //var posts = _dbContext.Posts.ToList();
                var posts = _postManager.GetAll().OrderByDescending(c => c.CreatedDate).ToList();

                //return Ok(posts);

                return CustomResult("Data loaded successfully", posts, HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        // get by Id
        [HttpGet("id")]
        public ActionResult<Post> GetById(int id)
        {
            try
            {
                var post = _postManager.GetById(id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // create data
        [HttpPost]
        public ActionResult<Post> Add(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;

                //_dbContext.Posts.Add(post);

                //bool isSaved = _dbContext.SaveChanges() > 0;

                bool isSaved = _postManager.Add(post);

                if (isSaved)
                {
                    return Created("", post);
                }

                return BadRequest("Post save failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // edit 
        [HttpPut]
        public ActionResult<Post> Edit(Post post) {

            try
            {
                if (post.Id == 0)
                {
                    return BadRequest("Id is missing");
                }

                bool isUpdate = _postManager.Update(post);

                if (isUpdate)
                {

                    return Ok(post);
                }

                return BadRequest("Post updated failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // delete
        [HttpDelete("id")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                var post = _postManager.GetById(id);

                if (post == null)
                {
                    return NotFound();
                }

                bool isDelete = _postManager.Delete(post);

                if (isDelete)
                {
                    return Ok("Post has been deleted");
                }

                return BadRequest("Post delete failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
