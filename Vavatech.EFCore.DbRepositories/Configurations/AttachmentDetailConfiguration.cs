using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sulmar.EFCore.Models;

namespace Vavatech.EFCore.DbRepositories.Configurations
{
    public class AttachmentDetailConfiguration : IEntityTypeConfiguration<AttachmentDetail>
    {
        public void Configure(EntityTypeBuilder<AttachmentDetail> builder)
        {
            builder.ToTable("Attachment");

            builder.Property(p => p.ContentType)
                .HasColumnName(nameof(Attachment.ContentType));

            builder.Property(p => p.FileName)
                .HasColumnName(nameof(Attachment.FileName));

        }
    }
}
