using Core.Entities;
using System;

namespace Application.Models
{
    public interface IUserFileUpdateModel
    {
        Guid FileId { get; set; }
        UserFileType Type { get; }
    }

    public class UserCreateModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }

    public class UserUpdateModel : UserCreateModel
    {
        public Guid Id { get; set; }
    }

    public class UserModel : UserUpdateModel
    {
        // It will be true if user is yourself
        public bool IsFriend { get; set; }
    }

    public class UserUpdateProfileModel : IUserFileUpdateModel
    {
        public Guid FileId { get; set; }

        public UserFileType Type => UserFileType.Profile;
    }

    public class UserUpdateCoverModel : IUserFileUpdateModel
    {
        public Guid FileId { get; set; }

        public UserFileType Type => UserFileType.Cover;
    }
}
