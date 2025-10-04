using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "ProductName is required.")]
        public string? ProductName { get; init; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int? CategoryId { get; init; } // FK

    }
}