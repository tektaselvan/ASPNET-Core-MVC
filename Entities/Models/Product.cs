using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "ProductName is required.")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "ProductName is required.")]
        public decimal Price { get; set; }
        public String? Summary { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; set; } // FK
        public Category? Category { get; set; }
        public bool ShowCase { get; set; }
    }
}