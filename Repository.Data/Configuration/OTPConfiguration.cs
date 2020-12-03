using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Configuration
{
    public class OTPConfiguration : IEntityTypeConfiguration<OTPModel>
    {
        public void Configure(EntityTypeBuilder<OTPModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
        }
    }
}
