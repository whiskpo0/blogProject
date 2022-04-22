using Nop.Web.Models;
using Nop.Web.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Factories
{
    public interface IBlogModelFactory
    {
        Task<BlogPostListModel> PrepareBlogPostListModelAsync(BlogPagingFilteringModel command); 
    }
}
