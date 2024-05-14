using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models.Dto;

namespace MyProject.Controllers
{
    public interface IProductsController
    {
        Task<IActionResult> CreateProductAsync([FromBody] ProductCreateDto productCreateDto);
        Task<IActionResult> GetProductAsync(int id);
    }
}