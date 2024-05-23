using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Interfaces;
using MyProject.Models;
using MyProject.Models.Dto;
using MyProject.src.Application.Dto;
using MyProject.src.Domain.Models.Exceptions;
using MyProject.src.Models;

namespace MyProject.Products.Controller
{
    [Route("api/product/create")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            try
            {
                var product = await _productService.CreateProductAsync(productCreateDto);

                var productDto = new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                };

                return Ok(productDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to save the product to the database.");
            }
        }

        [HttpGet("/product/{name}")]
        public async Task<IActionResult> FindByNameAsync(string name)
        {
            try
            {
                var product = await _productService.FindByNameAsync(name);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();

            }
        }

        [HttpPatch("/product/update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateDTO product)
        {

            var updateDto = new UpdateDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive
            };

            var updatedProduct = await _productService.UpdateAsync(updateDto);
            return Ok(updatedProduct);
        }
    }
}