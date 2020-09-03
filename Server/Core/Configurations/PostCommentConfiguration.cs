using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Core.Configurations
{
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostCommentEntity>
    {
        public void Configure(EntityTypeBuilder<PostCommentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Post).WithMany(x => x.PostComments).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
