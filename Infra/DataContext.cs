using Domain.Models;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PostMap());
    }

}

