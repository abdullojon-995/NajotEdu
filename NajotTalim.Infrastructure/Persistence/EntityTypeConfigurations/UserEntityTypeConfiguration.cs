using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NajotTalim.Domain.Entities;
using NajotTalim.Domain.Enums;

namespace NajotTalim.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasIndex(x => x.UserName)
                   .IsUnique();

            builder.HasData(new User()
            {
                Id = 1,
                FullName = "Adminbek Adminov",
                UserName = "Admin",
                PasswordHash = "0ECB2816A2503040F688FBCA733C728003EF613A0B7803DC1ACE1A01408630E0E9A52F18968A1F0B6D388950ABAD951685C934C4977251AED1F336650346C1E8",
                Role = UserRole.Admin
            });
        }
    }
}
