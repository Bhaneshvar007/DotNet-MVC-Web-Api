using InventoryManagement_System.Interface;
using InventoryManagement_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct product;
        private readonly ICetegory cetegory;

        public ProductController(IProduct product, ICetegory cetegory)
        {
            this.product = product;
            this.cetegory = cetegory;
        }

        [Route("GetAllProduct")]
        public async Task<IActionResult> Index()
        {
            var products = await this.product.GetProductAsync();
            
            return View(products);
        }



        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await cetegory.GetCategoryAsync();

            if (categories == null)
            {
                ViewBag.Categories = new List<CetegoryModel>(); // Ensure it's never null
            }
            else
            {
                ViewBag.Categories = categories;
            }

            return View();
        }


        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductModel productModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Categories = await cetegory.GetCategoryAsync();
            //    return View(productModel);
            //}

            ViewBag.message = await this.product.CreateProductAsynce(productModel);
            return RedirectToAction("Index");
        }

        [Route("GetProductById")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            return View(await this.product.GetProductByIdAsync(id));
        }

        [Route("UpdateProduct")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await this.product.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await cetegory.GetCategoryAsync();
            return View(product);
        }

        [Route("UpdateProduct")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductModel productModel)
        {
           

            ViewBag.Message = await product.UpdateProductAsync(productModel);
            return RedirectToAction("Index");
        }



        [Route("DeleteProduct")]
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            ViewBag.Message = await this.product.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

    }
}
