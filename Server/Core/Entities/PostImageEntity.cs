using System;

namespace Core.Entities
{
    public class PostImageEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }
        public virtual PostEntity Post { get; set; }

        public Guid FileId { get; set; }
        public virtual FileEntity File { get; set; }
    }
}
