using System;

namespace Core.Entities
{
    public class PostCommentEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }
        public virtual PostEntity Post { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public string Content { get; set; }
    }
}
