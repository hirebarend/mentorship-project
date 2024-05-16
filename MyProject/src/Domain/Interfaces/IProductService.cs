using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using MyProject.Models.Dto;
using MyProject.src.Models;

namespace MyProject.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(ProductCreateDto productCreateDto);
        Task<Product> GetProductAsync(int id);
    }
}