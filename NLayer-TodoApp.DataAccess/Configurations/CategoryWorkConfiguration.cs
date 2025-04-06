using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.Configurations;

public class CategoryWorkConfiguration : IEntityTypeConfiguration<CategoryWork>
{
    public void Configure(EntityTypeBuilder<CategoryWork> builder)
    {
        builder.HasKey(cw => new { cw.WorkId, cw.CategoryId });

        builder
            .HasOne(cw => cw.Category)
            .WithMany(cw => cw.Works)
            .HasForeignKey(cw => cw.CategoryId);

        builder
            .HasOne(cw => cw.Work)
            .WithMany(w => w.Categories)
            .HasForeignKey(cw => cw.WorkId);
    }
}