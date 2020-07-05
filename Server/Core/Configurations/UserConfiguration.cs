using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);            
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Address).IsRequired();
        }
    }
}
