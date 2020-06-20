using System;

namespace Core.Entities
{
    public class BaseEntity
    {
        public DateTimeOffset CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }

        public DateTimeOffset UpdatedDateTime { get; set; }
        public string UpdatedBy { get; set; }

        public DateTimeOffset DeletedDateTime { get; set; }
        public string DeletedBy { get; set; }
    }
}
