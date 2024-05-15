using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Data;
using MyProject.Interfaces;
using MyProject.Models;
using MyProject.Models.Dto;

namespace MyProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            if (string.IsNullOrEmpty(productCreateDto.Name) || productCreateDto.Price <= 0)
            {
                throw new ArgumentException("Name and price are required for a product.");
            }

            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                Description = productCreateDto.Description
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }

    // public class ProductRepository : IProductRepository
    // {
    //     private readonly MyDbContext _context;

    //     public ProductRepository(MyDbContext context)
    //     {
    //         _context = context;
    //     }

    //     public async Task<Product> CreateProductAsync(ProductCreateDto productCreateDto)
    //     {
    //         var product = new Product
    //         {
    //             Name = productCreateDto.Name,
    //             Price = productCreateDto.Price,
    //             Description = productCreateDto.Description
    //         };
    //         // await _context.Products.AddAsync(product);
    //         // await _context.SaveChangesAsync();

    //         return product;
    //     }

    //     public async Task<Product> GetProductAsync(int id)
    //     {
    //         return await _context.Products.FindAsync(id);
    //     }
    // }
}