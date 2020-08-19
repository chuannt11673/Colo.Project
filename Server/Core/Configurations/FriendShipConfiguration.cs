using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class FriendShipConfiguration : IEntityTypeConfiguration<FriendShipEntity>
    {
        public void Configure(EntityTypeBuilder<FriendShipEntity> builder)
        {
            builder.HasKey(x => new { x.SenderId, x.ReceiverId });
            builder.HasOne(sc => sc.Sender).WithMany().HasForeignKey(sc => sc.SenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(sc => sc.Receiver).WithMany().HasForeignKey(sc => sc.ReceiverId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
