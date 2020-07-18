﻿using System;

namespace Application.Models
{
    public class ChatCreateModel
    {
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Message { get; set; }
    }

    public class ChatUpdateModel : ChatCreateModel
    {
        public Guid Id { get; set; }
    }

    public class ChatModel : ChatUpdateModel
    {
        public string FromUserEmail { get; set; }
        public string ToUserEmail { get; set; }
    }

    public class ChatGetPagingationModel : PagingationRequestModel
    {
        public Guid UserId { get; set; }
    }
}