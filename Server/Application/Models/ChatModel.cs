using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class ChatCreateModel
    {
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Message { get; set; }
        public Guid[] FileIds { get; set; }
    }

    public class ChatUpdateModel : ChatCreateModel
    {
        public Guid Id { get; set; }
    }

    public class ChatModel : ChatUpdateModel
    {
        public string FromUserEmail { get; set; }
        public string ToUserEmail { get; set; }
        public FileModel[] FileModels { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
    }

    public class ChatGetPagingationModel : PagingationRequestModel
    {
        public Guid UserId { get; set; }
    }

    public class ChatItemModel
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Message { get; set; }
        public FileModel[] FileModels { get; set; }
    }
}
