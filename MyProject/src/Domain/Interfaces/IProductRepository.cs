using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using MyProject.Models.Dto;
using MyProject.src.Application.Dto;
using MyProject.src.Models;

namespace MyProject.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(ProductCreateDto productCreateDto);
        Task<Product> FindByNameAsync(string name);
        Task<Product> UpdateAsync(UpdateDTO product);
        Task<Product> DeleteAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}