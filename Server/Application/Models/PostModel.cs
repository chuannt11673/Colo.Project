using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class PostCreateModel
    {
        public string Content { get; set; }
        public Guid[] FileIds { get; set; }
    }

    public class PostModel : PostCreateModel
    {
        public Guid Id { get; set; }
        public BasicUserModel User { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public IEnumerable<FileModel> FileModels { get; set; }
        public IEnumerable<BasicUserModel> LikedUsers { get; set; }
    }
}
