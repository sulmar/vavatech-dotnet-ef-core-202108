using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.DbRepositories.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasOne(p => p.AttachmentDetail)
                .WithOne()
                .HasForeignKey<AttachmentDetail>(p=>p.Id);

            builder.ToTable("Attachment");

            builder.Property(p => p.ContentType)
               .HasColumnName(nameof(Attachment.ContentType));

            builder.Property(p => p.FileName)
                .HasColumnName(nameof(Attachment.FileName));
        }
    }
}
