using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        List<string> fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Graps",
            "Orange",
            "Cherry",

        };

        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }

        [HttpGet("{id}")]
        public string GetFruitsById(int id)
        {
            return fruits.ElementAt(id);
        }

        //post api
        [HttpPost]
        public void Post([FromBody] string value)
        {
            fruits.Add(value);
        }
    }
}
