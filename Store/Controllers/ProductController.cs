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
                return BadRequest(new JsonResult("Error while added a product"));
            }
            await Rep.AddProductAsync(product);
            return Ok(new JsonResult("Product added successfully"));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return new JsonResult("Product was not found");
            }
            else
            {
                await Rep.UpdateProductAsync(product);
                return new JsonResult("Product was update successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            Product findProduct = Rep.FindProduct(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            else
            {
                await Rep.DeleteProductAsync(findProduct);
                return new JsonResult("Product was deleted successfully");
            }
        }
    }
}
