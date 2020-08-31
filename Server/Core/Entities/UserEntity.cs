using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        public virtual IEnumerable<UserFileEntity> UserFiles { get; set; }
        public virtual UserFileEntity Avatar
        {
            get
            {
                var userFile = UserFiles.Where(x => x.Type == UserFileType.Profile).OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();

                return userFile ?? new UserFileEntity
                {
                    File = new FileEntity()
                };
            }
        }
        public virtual UserFileEntity Cover
        {
            get
            {
                var userFile = UserFiles.Where(x => x.Type == UserFileType.Cover).OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();

                return userFile ?? new UserFileEntity
                {
                    File = new FileEntity()
                };
            }
        }

        public virtual IEnumerable<FriendShipEntity> SendingFriendShips { get; set; }
        public virtual IEnumerable<FriendShipEntity> ReceivingFriendShips { get; set; }
        public virtual IEnumerable<UserEntity> Friends
        {
            get
            {
                var receivers = SendingFriendShips.Where(x => x.State == FriendShipState.Accepted).Select(x => x.Receiver);
                var senders = ReceivingFriendShips.Where(x => x.State == FriendShipState.Accepted).Select(x => x.Sender);

                return receivers.Union(senders);
            }
        }

        public virtual IEnumerable<UserLikeEntity> SendingUserLikes { get; set; }
        public virtual IEnumerable<UserLikeEntity> ReceivingUserLikes { get; set; }
    }

    public enum Gender
    {
        NotSelect = 0,
        Male = 1,
        Female = 2,
        Other = 3
    }
}
