using System;

namespace Application.Models
{
    public class PostCommentCreateModel
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }

    public class PostCommentModel : PostCommentCreateModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public BasicUserModel User { get; set; }
    }
}
