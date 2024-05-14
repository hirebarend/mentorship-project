using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Products.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
            {
                return BadRequest("Name and price are required for a product.");
            }

            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to save the product to the database.");
            }

            return Ok(new Models.Dto.ProductCreateDto(product));
        }
    }
}