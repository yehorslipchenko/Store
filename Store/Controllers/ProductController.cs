using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        public IRepository Rep { get; set; }

        public ProductController(IRepository rep)
        {
            Rep = rep;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Rep.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error while added a product");
            }
            Rep.AddProduct(product);
            return new JsonResult("Product added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (product == null || id != product.Id)
            {
                return new JsonResult("Product was not found");
            }
            else
            {
                Rep.UpdateProduct(product);
                return new JsonResult("Product was update successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            Product findProduct = Rep.FindProduct(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            else
            {
                Rep.DeleteProduct(findProduct);
                return new JsonResult("Product was deleted successfully");
            }
        }
    }
}
