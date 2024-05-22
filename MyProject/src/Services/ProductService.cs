using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Data;
using MyProject.Interfaces;
using MyProject.Models;
using MyProject.Models.Dto;
using MyProject.src.Application.Dto;
using MyProject.src.Domain.Models.Exceptions;
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


        public async Task<Product> FindByNameAsync(string name)
        {
            try
            {
                return await _productRepository.FindByNameAsync(name);
            }
            catch (Exception)
            {
                // Return a default value or throw a custom exception
                throw new NotFoundException("Product not found");
            }
        }

        public async Task<Product> UpdateAsync(UpdateDTO product)
        {
            try
            {
                return await _productRepository.UpdateAsync(product);
            }
            catch (Exception)
            {
                // Return a default value or throw a custom exception
                throw new NotFoundException("Product not found");
            }
        }
    }
}