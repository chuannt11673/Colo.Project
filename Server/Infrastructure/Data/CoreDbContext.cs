using Core.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserConfiguration)));
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FriendShipEntity> FriendShips { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<FileEntity> Files { get; set; }
    }
}
