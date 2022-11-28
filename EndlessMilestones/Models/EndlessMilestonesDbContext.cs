using System;
using EndlessMilestones.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EndlessMilestones.Models
{
    public class EndlessMilestonesDbContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public EndlessMilestonesDbContext(DbContextOptions<EndlessMilestonesDbContext> options, IConfiguration configuration)
            :base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("EndlessMilestones");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Goals> Goals { get; set; } = null!;
        public DbSet<methods> methods { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
    }
}

