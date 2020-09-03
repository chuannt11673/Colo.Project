using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class PostEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public virtual IEnumerable<PostImageEntity> PostImages { get; set; }
        public virtual IEnumerable<PostLikeEntity> PostLikes { get; set; }
        public virtual IEnumerable<PostCommentEntity> PostComments { get; set; }
    }
}
