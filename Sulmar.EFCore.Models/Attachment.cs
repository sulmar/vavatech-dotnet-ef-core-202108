using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.EFCore.Models
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }

        public virtual AttachmentDetail AttachmentDetail { get; set; }

    }
}
