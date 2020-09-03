using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Core.Configurations
{
    public class PostLikeConfiguration : IEntityTypeConfiguration<PostLikeEntity>
    {
        public void Configure(EntityTypeBuilder<PostLikeEntity> builder)
        {
            builder.HasKey(x => new { x.PostId, x.UserId });
            builder.HasOne(x => x.Post).WithMany(x => x.PostLikes).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
