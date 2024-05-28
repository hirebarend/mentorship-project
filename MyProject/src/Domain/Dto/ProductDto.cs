using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MyProject.src.Domain.ValueObjects;

namespace MyProject.Models.Dto
{
    public class ProductDto
    {
        public required string? Name { get; set; }
        public required Price Price { get; set; }
        public required string? Description { get; set; }
    }
}