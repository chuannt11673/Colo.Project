using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class ChatFileConfiguration : IEntityTypeConfiguration<ChatFileEntity>
    {
        public void Configure(EntityTypeBuilder<ChatFileEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Chat).WithMany(x => x.ChatFiles).HasForeignKey(x => x.ChatId);
            builder.HasOne(x => x.File).WithMany().HasForeignKey(x => x.FileId);
        }
    }
}
