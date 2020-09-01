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
    }
}
