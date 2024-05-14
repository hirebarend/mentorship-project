using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models.Dto
{
    public class ProductCreateDto
    {
        public ProductCreateDto(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Description = product.Description;
        }

        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}