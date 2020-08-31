using Core.Entities;
using System;

namespace Application.Models
{
    public class UserLikeModel
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public UserLikeState State { get; set; }
    }
}
