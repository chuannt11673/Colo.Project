using System;

namespace Core.Entities
{
    public class UserLikeEntity : BaseEntity
    {
        public Guid SenderId { get; set; }
        public virtual UserEntity Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public virtual UserEntity Receiver { get; set; }

        public UserLikeState State { get; set; }
    }

    public enum UserLikeState
    {
        None = 0,
        Like = 1
    }
}
