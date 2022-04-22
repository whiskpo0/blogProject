using System;
using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Blogs
{
    public class BlogPostModel : BaseNopEntityModel
    {
        public BlogPostModel()
        {
            Tags = new List<string>();           
        }

        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string BodyOverview { get; set; }
        public DateTime CreatedOn { get; set; }

        public IList<string> Tags { get; set; }
    }
}
