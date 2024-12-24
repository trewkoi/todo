using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Models;

namespace Todo.Api.Data.Mappings;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TaskId)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);
        
        builder.Property(x => x.AuthorId)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);
        
        builder.Property(x => x.Content)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}