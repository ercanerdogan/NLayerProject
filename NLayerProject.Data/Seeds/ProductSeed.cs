using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _categoryIds;
        public ProductSeed(int[] categoryIds)
        {
            _categoryIds = categoryIds;

        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pencil", Price = 12.50m, Stock =100, CategoryId = _categoryIds[0]},
                new Product { Id = 2, Name = "NoteBook Small", Price = 8.50m, Stock = 500, CategoryId = _categoryIds[1] },
                new Product { Id = 3, Name = "NoteBook Medium", Price = 28m, Stock = 200, CategoryId = _categoryIds[1] },
                new Product { Id = 4, Name = "NoteBook Large", Price = 28m, Stock = 200, CategoryId = _categoryIds[1] }

            );
                
            
        }
    }
}
