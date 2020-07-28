using System;

namespace Core.Entities
{
    public class FileEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
