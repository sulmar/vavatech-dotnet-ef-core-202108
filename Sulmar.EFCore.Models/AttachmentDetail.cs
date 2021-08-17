namespace Sulmar.EFCore.Models
{
    public class AttachmentDetail : BaseEntity
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
