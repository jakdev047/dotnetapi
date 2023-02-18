using EF.Core.Repository.Interface.Manager;
using MyWebAPI.Models;

namespace MyWebAPI.Interfaces.Manager
{
    public interface IPostManager:ICommonManager <Post> {

        Post GetById(int id);

        ICollection<Post> GetAll(string title);

        ICollection<Post> SearchPost(string title);

        ICollection<Post> GetPosts(int page, int pageSize);
    }
}
