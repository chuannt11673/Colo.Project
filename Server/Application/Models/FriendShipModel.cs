using Core.Entities;
using System;

namespace Application.Models
{
    public class FriendShipModel
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public FriendShipState State { get; set; }
    }
}
