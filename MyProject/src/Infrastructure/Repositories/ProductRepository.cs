using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Interfaces;
using MyProject.Models.Dto;
using MyProject.src.Application.Dto;
using MyProject.src.Domain.Models.Exceptions;
using MyProject.src.Models;

namespace MyProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        const bool ProductActive = true;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                Description = productCreateDto.Description,
                IsActive = ProductActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id) ?? throw new InvalidOperationException("Product not found");
            return product;
        }

        public async Task<Product> FindByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
            if (product == null)
            {
                // Throw a NotFoundException with a null innerException
                throw new NotFoundException("Product not found in repositor");
            }
            return product;
        }

        public async Task<Product> UpdateAsync(UpdateDTO product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            // Console.WriteLine(existingProduct);
            if (existingProduct == null)
            {
                throw new NotFoundException("Product not found in repository");
            }

            existingProduct.Id = product.Id;
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.IsActive = product.IsActive;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}