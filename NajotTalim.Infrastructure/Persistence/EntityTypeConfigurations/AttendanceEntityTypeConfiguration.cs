﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NajotTalim.Domain.Entities;

namespace NajotTalim.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Lesson)
                   .WithMany(x => x.Attendances)
                   .HasForeignKey(x => x.LessonId);

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Attendances)
                   .HasForeignKey(x => x.StudentId);
        }
    }
}
