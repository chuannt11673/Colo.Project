using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        public virtual ICollection<FriendShipEntity> SentFriendShips { get; set; }
        public virtual ICollection<FriendShipEntity> ReceivedFriendShips { get; set; }
    }
    
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
