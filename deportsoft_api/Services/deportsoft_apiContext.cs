using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using deportsoft_api.Models;

namespace deportsoft_api.Services;

public class deportsoft_apiContext : IdentityDbContext<ApplicationUser>
{
    public deportsoft_apiContext(DbContextOptions options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Deportist> Deportsists { get; set; }
    public DbSet<Rutina> Rutinas { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var client = new IdentityRole("client");
        client.NormalizedName = "client";


        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";


        builder.Entity<IdentityRole>().HasData(admin, client);
    }
}
