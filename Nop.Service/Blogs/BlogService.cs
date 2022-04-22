using Nop.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Service.Blogs
{
    public class BlogService : IBlogService
    {
        public Task<IList<BlogPost>> GetAllBlogPostsAsync(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BlogPost>> GetAllBlogPostsByTagAsync(string tag = "")
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> ParseTagsAsync(BlogPost blogPost)
        {
            if (blogPost.Tags == null)
            {
                return new List<string>(); 
            }

            var tags = await blogPost.Tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(tag => tag.Trim())
                .Where(tag => !string.IsNullOrEmpty(tag))
                .ToListAsync();

            return tags; 
        }
    }
}
