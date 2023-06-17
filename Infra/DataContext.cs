using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Tag> Tags { get; set; }

    //public DbSet<UserRole> UserRoles { get; set; }

    //public DbSet<PostTag> PostTags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=P@ssw0rd;");


    }

}

