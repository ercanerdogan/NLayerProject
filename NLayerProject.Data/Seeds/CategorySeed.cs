using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _categoryIds;

        public CategorySeed(int[] categoryIds)
        {
            _categoryIds = categoryIds;

        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id= _categoryIds[0], Name = "Pencils"},
                new Category { Id = _categoryIds[1], Name = "Notebooks" }
            );
            
        }
    }
}
