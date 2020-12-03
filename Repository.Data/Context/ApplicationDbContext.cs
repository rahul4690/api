using Microsoft.EntityFrameworkCore;
using Repository.Data.Configuration;
using Repository.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUserModel> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRoleModel> ApplicationUserRoles { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<OTPModel> OtpModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

    }
}
