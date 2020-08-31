using System;

namespace Core.Entities
{
    public class NotificationEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public bool ForAllUsers { get; set; }

        public Guid? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }

    public enum NotificationType
    {
        Message = 1,
        Like = 2
    }
}
