using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(false);
        }
    }
}
