using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendShipEntity>().HasKey(x => new { x.SenderId, x.ReceiverId });
            modelBuilder.Entity<FriendShipEntity>().HasOne(x => x.Sender).WithMany(x => x.SentFriendShips).HasForeignKey(x => x.SenderId);
            modelBuilder.Entity<FriendShipEntity>().HasOne(x => x.Receiver).WithMany(x => x.ReceivedFriendShips).HasForeignKey(x => x.ReceiverId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FriendShipEntity> FriendShips { get; set; }
    }
}
