using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.src.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public partial class Product
    {
        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}