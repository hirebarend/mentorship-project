using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyProject.src.Domain.ValueObjects;

namespace MyProject.src.Application.Dto
{
    public class UpdateDTO
    {
        public int Id { get; set;}
        public required string? Name { get; set; }
        public required Price Price { get; set; }
        public required string? Description { get; set; }
        public required IsActive IsActive { get; set; }
    }
}