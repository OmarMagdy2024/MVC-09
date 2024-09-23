using Company_DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_DAL.Connection
{
    public class CompanyDBContext:IdentityDbContext<ApplicationUser>
    {
        #region Constructor
        public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options) { }
        #endregion

        #region Property
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion

        #region Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                        .HasMany(d => d.employees)
                        .WithOne(d => d.Department)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                        .Property(e => e.Gender)
                        .HasConversion(
                                      (Gender) => Gender.ToString(),
                                      (GenderString) => (Gender)Enum.Parse(typeof(Gender), GenderString, true)
                                      );
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>()
                        .ToTable("Users");
            modelBuilder.Entity<IdentityRole>()
                        .ToTable("Roles");
        }
        #endregion
    }
}
