using GeometryViewerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeometryViewerAPI.DB
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("SQLite"));
        }

        public DbSet<Bucket> Buckets { get; set; }
    }
}
