using Sulmar.EFCore.Models;

namespace Vavatech.EFCore.IRepositories
{
    public interface IAttachmentRepository : IEntityRepository<Attachment>
    {
        
    }

    public interface IAttachmentDetailRepository
    {
        AttachmentDetail Get(int attachmentId);
    }



}
