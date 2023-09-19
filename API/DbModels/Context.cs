using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace API.DbModels
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
