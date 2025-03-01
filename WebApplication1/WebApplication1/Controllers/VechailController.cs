using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VechailController : ControllerBase 
    {
        static List<Vechail> vechails = new List<Vechail>();
        // GET: api/<VechailController>
        [HttpGet]
        public IEnumerable<Vechail> Get()
        {
            return vechails;
        }

        // GET api/<VechailController>/5
        [HttpGet("{id}")]
        public Vechail Get(int id)
        {
            return vechails.FirstOrDefault(e => e.Id == id);
        }

        // POST api/<VechailController>
        [HttpPost]
        public void Post([FromBody] Vechail value)
        {
            vechails.Add(value);
        }

        // PUT api/<VechailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vechail value)
        {
            int i = vechails.FindIndex(e => e.Id == id);
            if (i >= 0) {
                vechails[i] = value;
            }
        }

        // DELETE api/<VechailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            vechails.RemoveAll(e => e.Id == id);
        }
    }
}
