using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual IEnumerable<UserFileEntity> UserFiles { get; set; }
        public virtual UserFileEntity UserProfile
        {
            get
            {
                return UserFiles.Where(x => x.Type == UserFileType.Profile).OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();
            }
        }
        public virtual UserFileEntity UserCover
        {
            get
            {
                return UserFiles.Where(x => x.Type == UserFileType.Cover).OrderByDescending(x => x.CreatedDateTime).FirstOrDefault();
            }
        }
    }
    
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
