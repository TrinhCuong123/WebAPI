using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace api.Data
{
  public class ApplicationDBContext : IdentityDbContext<AppUser>
  {
    public ApplicationDBContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {

    }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<Portfolio> Portfolio { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Portfolio>(x => x.HasKey(p => new {p.AppUserId, p.StockID}));

      builder.Entity<Portfolio>()
        .HasOne(u => u.AppUser)
        .WithMany(u => u.portfolios)
        .HasForeignKey(p => p.AppUserId);
      
      builder.Entity<Portfolio>()
        .HasOne(u => u.Stock)
        .WithMany(u => u.portfolios)
        .HasForeignKey(p => p.StockID);


      List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
      builder.Entity<IdentityRole>().HasData(roles);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
  }
}