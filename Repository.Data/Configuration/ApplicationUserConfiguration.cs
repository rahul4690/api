using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUserModel>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne<ApplicationUserRoleModel>(x => x.role).WithMany(x => x.applicationUsers).HasForeignKey(x => x.roleId).IsRequired();
            builder.Property(x => x.name).IsRequired().HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.email).IsRequired().HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.mobile).IsRequired().HasMaxLength(20).HasDefaultValue("");
            builder.Property(x => x.isActive).HasDefaultValue(false);
            builder.Property(x => x.country).HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.state).HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.city).HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.pincode).HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.image).HasMaxLength(50).HasDefaultValue("");
            builder.Property(x => x.aboutMe).HasMaxLength(50).HasDefaultValue("");

        }
    }
}
