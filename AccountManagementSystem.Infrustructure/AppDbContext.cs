using AccountManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Infrustructure
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(string connectionString, string migrationAssembly)
        {
            _migrationAssembly = migrationAssembly;
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
