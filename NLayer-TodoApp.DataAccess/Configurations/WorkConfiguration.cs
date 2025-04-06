using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer_TodoApp.Entities.Domains;

namespace NLayer_TodoApp.DataAccess.Configurations;

public class WorkConfiguration : IEntityTypeConfiguration<Work>
{

    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Definition).HasMaxLength(350);
        builder.Property(x => x.Definition).IsRequired(true);
        builder.Property(x => x.isCompleted).IsRequired(true);



    }
}