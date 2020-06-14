using System;
using System.Collections.Generic;
using System.Text;
using FarmEasy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmEasy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<SoilType> SoilTypes { get; set; }
        public DbSet<CropDetails> CropDetails { get; set; }
        public DbSet<CropSoilMapping> CropSoilMappings { get; set; }

    }
}
