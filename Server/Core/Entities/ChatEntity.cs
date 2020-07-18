using System;

namespace Core.Entities
{
    public class ChatEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid FromUserId { get; set; }
        public UserEntity FromUser { get; set; }

        public Guid ToUserId { get; set; }
        public UserEntity ToUser { get; set; }

        public string Message { get; set; }
    }
}
