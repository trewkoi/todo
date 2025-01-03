using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Models;

namespace Todo.Api.Data.Mappings;

public class TodoTaskMapping : IEntityTypeConfiguration<TodoTask>
{
    public void Configure(EntityTypeBuilder<TodoTask> builder)
    {
        builder.ToTable("TodoTask");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);
        
        builder.Property(x => x.Description)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);
        
        builder.Property(x => x.DueDate)
            .IsRequired(false);
        
        builder.Property(x => x.Completed)
            .IsRequired();

        builder.Property(x => x.Priority)
            .HasColumnType("SMALLINT");
        
        builder.Property(x => x.Status)
            .HasColumnType("SMALLINT");

        builder.Property(x => x.AssignedTo)
            .IsRequired()
            .HasColumnType("VARCHAR");
    }
}