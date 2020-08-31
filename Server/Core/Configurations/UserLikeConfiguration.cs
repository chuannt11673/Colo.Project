using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class UserLikeConfiguration : IEntityTypeConfiguration<UserLikeEntity>
    {
        public void Configure(EntityTypeBuilder<UserLikeEntity> builder)
        {
            builder.HasKey(x => new { x.SenderId, x.ReceiverId });
            builder.HasOne(x => x.Sender).WithMany(x => x.SendingUserLikes).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Receiver).WithMany(x => x.ReceivingUserLikes).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
