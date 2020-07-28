using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class FileCreateModel
    {
        public string Base64 { get; set; }
    }

    public class FileModel
    {
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
