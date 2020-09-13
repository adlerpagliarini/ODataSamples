using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataSamples.Domain;

namespace ODataSamples.Infrastructure.Mappings
{
    public class DeveloperTypeConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            builder.HasMany(t => t.TasksToDo).WithOne().HasForeignKey(k => k.UserId);
        }
    }
}
