using System;

namespace Core.Entities
{
    public class UserFileEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public Guid FileId { get; set; }
        public virtual FileEntity File { get; set; }

        public UserFileType Type { get; set; }
    }

    public enum UserFileType
    {
        Profile = 1,
        Cover = 2
    }
}
