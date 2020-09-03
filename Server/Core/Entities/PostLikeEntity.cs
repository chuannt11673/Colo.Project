using System;

namespace Core.Entities
{
    public class PostLikeEntity : BaseEntity
    {
        public Guid PostId { get; set; }
        public virtual PostEntity Post { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
