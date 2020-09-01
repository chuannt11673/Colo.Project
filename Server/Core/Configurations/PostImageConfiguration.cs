using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImageEntity>
    {
        public void Configure(EntityTypeBuilder<PostImageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Post).WithMany(x => x.PostImages).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.File).WithMany().HasForeignKey(x => x.FileId);
        }
    }
}
