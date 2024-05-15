using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Interfaces;
using MyProject.Models;
using MyProject.Models.Dto;

namespace MyProject.Products.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductCreateDto productCreateDto)
        {
            try
            {
                var product = await _productRepository.CreateProductAsync(productCreateDto);

                var productDto = new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                };

                var url = Url.Action(nameof(GetProductAsync), new { id = product.Id });
                return Created(url, productDto);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            return Ok(productDto);
        }
    }
}