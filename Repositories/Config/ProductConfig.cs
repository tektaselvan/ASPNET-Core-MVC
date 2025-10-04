using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product() { ProductId = 1, CategoryId=2, ImageUrl="/images/1.jpg", ProductName = "Computer", Price = 50000,ShowCase = false },
                new Product() { ProductId = 2, CategoryId=2, ImageUrl="/images/2.jpg", ProductName = "Keyboard", Price = 40000,ShowCase = false },
                new Product() { ProductId = 3, CategoryId=2, ImageUrl="/images/3.jpg", ProductName = "Mouse", Price = 30000,ShowCase = false },
                new Product() { ProductId = 4, CategoryId=2, ImageUrl="/images/4.jpg", ProductName = "Deck", Price = 20000 ,ShowCase = false},
                new Product() { ProductId = 5, CategoryId=1, ImageUrl="/images/5.jpg", ProductName = "History", Price = 200,ShowCase = false },
                new Product() { ProductId = 6, CategoryId=1, ImageUrl="/images/6.jpg", ProductName = "Hamlet", Price = 300,ShowCase = false },
                new Product() { ProductId = 7, CategoryId=1, ImageUrl="/images/6.jpg", ProductName = "XP-Pen", Price = 1145, ShowCase = true },
                new Product() { ProductId = 8, CategoryId=2, ImageUrl="/images/6.jpg", ProductName = "Galaxy FE", Price = 8000,ShowCase = true },
                new Product() { ProductId = 9, CategoryId=1, ImageUrl="/images/6.jpg", ProductName = "HP Mouse", Price = 750, ShowCase = true }
            );
        }
    }
}