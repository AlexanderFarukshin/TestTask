using Microsoft.EntityFrameworkCore;
using System;
 
namespace Task.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=userstoredb; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }

}