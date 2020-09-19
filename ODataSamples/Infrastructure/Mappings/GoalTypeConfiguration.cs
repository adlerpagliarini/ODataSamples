using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataSamples.Domain;

namespace ODataSamples.Infrastructure.Mappings
{
    public class GoalTypeConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Title).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
