using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Context;
using MyWebAPI.Interfaces.Repository;
using MyWebAPI.Models;

namespace MyWebAPI.Repository
{
    public class PostRepository : CommonRepository<Post>,IPostRepository
    {
        public PostRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {

        }
    }
}
