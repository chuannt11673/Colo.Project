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
            builder.HasOne(sc => sc.Sender).WithMany(x => x.SendingFriendShips).HasForeignKey(sc => sc.SenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(sc => sc.Receiver).WithMany(x => x.ReceivingFriendShips).HasForeignKey(sc => sc.ReceiverId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
