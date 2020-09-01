using Core.Entities;
using System;
using System.Collections.Generic;

namespace Application.Models
{
    public interface IUserFileUpdateModel
    {
        Guid FileId { get; set; }
        UserFileType Type { get; }
    }

    public class BasicUserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }

    public class UserCreateModel
    {
    }

    public class UserUpdateModel : UserCreateModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }

    public class UserModel : UserUpdateModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }

        public IEnumerable<BasicUserModel> Friends { get; set; }
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
