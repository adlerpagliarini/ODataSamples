using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataSamples.Domain;

namespace ODataSamples.Infrastructure.Mappings
{
    public class TaskToDoTypeConfiguration : IEntityTypeConfiguration<TaskToDo>
    {
        public void Configure(EntityTypeBuilder<TaskToDo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.DeadLine).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
