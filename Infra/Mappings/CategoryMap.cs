using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Slug, "IDX_Category_Slug").IsUnique();

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(c => c.Slug)
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .IsRequired()
            .HasMaxLength(200);

    }
}

