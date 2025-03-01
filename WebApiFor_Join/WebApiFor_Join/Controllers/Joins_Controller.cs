using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiFor_Join.Interface;
using WebApiFor_Join.Models;

namespace WebApiFor_Join.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Joins_Controller : ControllerBase
    {
        private readonly ICetegoryProducts cetegoryProducts;
        public Joins_Controller(ICetegoryProducts cetegoryProducts )
        {
             this.cetegoryProducts = cetegoryProducts;
        }

        [HttpGet("get")]
        public async Task<List<Products>> getCetegory()
        {
            return await cetegoryProducts.GetProductsAsync();
        }

         
    }
}
