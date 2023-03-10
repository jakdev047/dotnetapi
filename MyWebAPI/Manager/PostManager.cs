using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using MyWebAPI.Context;
using MyWebAPI.Interfaces.Manager;
using MyWebAPI.Models;
using MyWebAPI.Repository;

namespace MyWebAPI.Manager
{
    public class PostManager : CommonManager<Post>,IPostManager
    {
        public PostManager(ApplicationDbContext _dbContext) : base(new PostRepository(_dbContext))
        {

        }

        public ICollection<Post> GetAll(string title)
        {
            return Get(c => c.Title.ToLower() == title.ToLower());
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<Post> GetPosts(int page, int pageSize)
        {
            if(page <= 1)
            {
                page = 0;
            }

            int totalNumber = page * pageSize;

            return GetAll().Skip(totalNumber).Take(pageSize).ToList();
        }

        public ICollection<Post> SearchPost(string text)
        {
            return Get(c => c.Title.ToLower().Contains(text.ToLower()));
        }
    }
}
