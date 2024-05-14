using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Models;
using MyProject.Models.Dto;

namespace MyProject.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(ProductCreateDto productCreateDto);
    }
}