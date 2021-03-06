﻿using Core.Entities;
using System;

namespace Application.Models
{
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
    }
}
