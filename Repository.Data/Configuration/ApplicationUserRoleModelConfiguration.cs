using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Configuration
{
    public class ApplicationUserRoleModelConfiguration : IEntityTypeConfiguration<ApplicationUserRoleModel>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRoleModel> builder)
        {
            builder.HasKey(x => x.id);
        }

    }
}
