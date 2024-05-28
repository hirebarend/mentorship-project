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
            if (string.IsNullOrEmpty(productCreateDto.Name))
            {
                throw new ArgumentException("Name is required.");
            }
            try
            {
                return await _productRepository.CreateProductAsync(productCreateDto);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Product> FindByNameAsync(string name)
        {
            try
            {
                return await _productRepository.FindByNameAsync(name);
            }
            catch (Exception)
            {
                throw new NotFoundException("Product not found");
            }
        }

        public async Task<Product> UpdateAsync(UpdateDTO product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<Product> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}