using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.src.Application.Dto
{
    public class UpdateDTO
    {
        public int Id { get; set;}
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string? Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}