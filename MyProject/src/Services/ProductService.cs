using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Data;
using MyProject.Interfaces;
using MyProject.Models;
using MyProject.Models.Dto;
using MyProject.src.Models;

namespace MyProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            if (string.IsNullOrEmpty(productCreateDto.Name) || productCreateDto.Price <= 0)
            {
                throw new ArgumentException("Name and price are required for a product.");
            }
            
            return await _productRepository.CreateProductAsync(productCreateDto);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productRepository.GetProductAsync(id);
        }
    }
}