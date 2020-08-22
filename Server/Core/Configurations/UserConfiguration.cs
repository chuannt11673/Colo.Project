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
            builder.HasIndex(x => x.Email).IsClustered(false).IsUnique();
            builder.Property(x => x.Email).IsRequired();

            builder.Ignore(x => x.Avatar);
            builder.Ignore(x => x.Cover);
            builder.Ignore(x => x.Friends);
        }
    }
}
