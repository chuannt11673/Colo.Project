using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class FriendShipEntity : BaseEntity
    {
        public Guid SenderId { get; set; }
        public UserEntity Sender { get; set; }
        public Guid ReceiverId { get; set; }
        public UserEntity Receiver { get; set; }

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
