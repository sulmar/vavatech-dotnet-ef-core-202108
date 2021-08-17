using Bogus;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.Fakers
{
    public class AttachmentFaker : Faker<Attachment>
    {
        public AttachmentFaker(Faker<AttachmentDetail> faker)
        {
            RuleFor(p => p.ContentType, f => "image/png");
            RuleFor(p => p.FileName, f => "plik.jpg");
            RuleFor(p => p.AttachmentDetail, f => faker.Generate());
        }
    }


    public class AttachmentDetailFaker : Faker<AttachmentDetail>
    {
        public AttachmentDetailFaker()
        {
            // RuleFor(p => p.ContentType, f => "image/png");
            RuleFor(p => p.Content, f =>
            {
                string url = "https://picsum.photos/400/500";

                var client = new WebClient();

                return client.DownloadData(url);

            });

            // RuleFor(p => p.FileName, f => "plik.jpg");

        }
    }
}
