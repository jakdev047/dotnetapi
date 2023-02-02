using EF.Core.Repository.Interface.Manager;
using MyWebAPI.Models;

namespace MyWebAPI.Interfaces.Manager
{
    public interface IPostManager:ICommonManager <Post> {

        Post GetById(int id);
    }
}
