using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyProject.Models.Dto
{
    public class ProductCreateDto
    {
        [JsonConstructor]
        public ProductCreateDto(string name, decimal price, string? description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}