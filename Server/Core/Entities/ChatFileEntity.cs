using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ChatFileEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid ChatId { get; set; }
        public virtual ChatEntity Chat { get; set; }

        public Guid FileId { get; set; }
        public virtual FileEntity File { get; set; }
    }
}
