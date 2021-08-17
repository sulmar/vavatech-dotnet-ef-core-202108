using Sulmar.EFCore.Models;
using System.Linq;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbAttachmentRepository : DbEntityRepository<Attachment>, IAttachmentRepository
    {
        public DbAttachmentRepository(ShopContext context) : base(context)
        {
        }

    }

    public class DbAttachmentDetailRepository : DbEntityRepository<AttachmentDetail>, IAttachmentDetailRepository
    {
        public DbAttachmentDetailRepository(ShopContext context) : base(context)
        {
        }

    }
}
