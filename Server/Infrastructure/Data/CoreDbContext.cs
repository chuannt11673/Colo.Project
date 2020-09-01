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
        public DbSet<ChatFileEntity> ChatFileEntity { get; set; }
        public DbSet<UserFileEntity> UserFileEntity { get; set; }
        public DbSet<UserLikeEntity> UserLikes { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<PostImageEntity> PostImages { get; set; }
    }
}
