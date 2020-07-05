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
            builder.HasOne<UserEntity>(sc => sc.Sender)
                .WithMany(s => s.SentFriendShips)
                .HasForeignKey(sc => sc.SenderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<UserEntity>(sc => sc.Receiver)
                .WithMany(s => s.ReceivedFriendShips)
                .HasForeignKey(sc => sc.ReceiverId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
