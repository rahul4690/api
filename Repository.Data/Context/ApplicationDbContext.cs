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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
