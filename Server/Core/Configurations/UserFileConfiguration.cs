using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class UserFileConfiguration : IEntityTypeConfiguration<UserFileEntity>
    {
        public void Configure(EntityTypeBuilder<UserFileEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.UserFiles).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.File).WithMany().HasForeignKey(x => x.FileId);
        }
    }
}
