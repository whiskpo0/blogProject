﻿using Nop.Web.Framework.Models;
using System.Collections.Generic;

namespace Nop.Web.Models.Blogs
{
    public class BlogPostListModel : BaseNopModel
    {
        public BlogPostListModel()
        {
            PagingFilteringContext = new BlogPagingFilteringModel();
            BlogPosts = new List<BlogPostModel>(); 
        }

        public BlogPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<BlogPostModel> BlogPosts { get; set; }

    }
}
