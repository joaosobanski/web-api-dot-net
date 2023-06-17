
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Slug, "IDX_Post_Slug").IsUnique();

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnType("SMALLDATETIME")
            //.HasDefaultValue(DateTime.Now.ToUniversalTime())
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Author")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Category")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>(
                "PostTag",
                post => post
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                tag => tag
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
            );

    }

}


