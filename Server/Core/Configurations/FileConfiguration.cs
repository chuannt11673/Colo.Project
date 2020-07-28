using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
    {
        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
