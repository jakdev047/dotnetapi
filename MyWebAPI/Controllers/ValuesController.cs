using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string GetName()
        {
            return "test";
        }

        [HttpGet]
        public string GetFullName()
        {
            return "Jubayer Alam Khan";
        }
    }
}
