using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Blogs
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string BodyOverview { get; set; }
        public string Tags { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateutc { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
