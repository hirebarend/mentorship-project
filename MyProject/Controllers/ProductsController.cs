using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models;
using MyProject.Models.Dto;

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
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
    {
        if (string.IsNullOrEmpty(productCreateDto.Name) || productCreateDto.Price <= 0)
        {
            return BadRequest("Name and price are required for a product.");
        }

        try
        {
            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                Description = productCreateDto.Description
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            // Log the exception or handle it as necessary
            return StatusCode(500, "Failed to save the product to the database.");
        }

        // Return a Product object without the Id, UpdatedAt, and IsActive properties
        return Ok(productCreateDto);
    }
}
}