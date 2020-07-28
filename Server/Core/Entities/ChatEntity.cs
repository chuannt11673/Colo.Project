using System;

namespace Core.Entities
{
    public class ChatEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid FromUserId { get; set; }
        public virtual UserEntity FromUser { get; set; }

        public Guid ToUserId { get; set; }
        public virtual UserEntity ToUser { get; set; }

        public string Message { get; set; }
    }
}
