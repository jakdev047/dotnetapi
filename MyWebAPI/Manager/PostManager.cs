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
    }
}
