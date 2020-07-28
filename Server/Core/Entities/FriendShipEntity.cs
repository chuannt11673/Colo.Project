using System;

namespace Core.Entities
{
    public class FriendShipEntity : BaseEntity
    {
        public Guid SenderId { get; set; }
        public virtual UserEntity Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public virtual UserEntity Receiver { get; set; }

        public FriendShipState State { get; set; }
    }

    public enum FriendShipState
    {
        Requested = 1,
        Accepted = 2,
        Declined = 3,
        Blocked = 4
    }
}
