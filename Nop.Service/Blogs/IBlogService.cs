using Nop.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Service.Blogs
{
    public interface IBlogService
    {
        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="dateFrom">Filter by created date; null if you want to get all records</param>
        /// <param name="dateTo">Filter by created date; null if you want to get all records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the blog posts
        /// </returns>
        Task<IList<BlogPost>> GetAllBlogPostsAsync(DateTime? dateFrom = null, DateTime? dateTo = null);
        Task<IList<BlogPost>> GetAllBlogPostsByTagAsync(string tag = "");
        Task<IList<string>> ParseTagsAsync(BlogPost blogPost);
    }
}
