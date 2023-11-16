using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NajotTalim.Domain.Entities;

namespace NajotTalim.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Group)
                   .WithMany(x => x.Lessons)
                   .HasForeignKey(x => x.GroupId);
        }
    }
}
