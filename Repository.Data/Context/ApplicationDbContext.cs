using Microsoft.EntityFrameworkCore;
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

    }
}
