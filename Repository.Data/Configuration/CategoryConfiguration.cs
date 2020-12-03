using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.Property(x => x.categoryCode).IsRequired();
            builder.HasKey(x => x.categoryCode);
        }
    }
}
