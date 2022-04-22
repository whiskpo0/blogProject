using Nop.Core.Domain.Blogs;
using Nop.Data;
using Nop.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Service.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<BlogPost> _blogPostRepository;
        private readonly CoreDbContexts _db;

        public BlogService(IRepository<BlogPost> blogPostRepository, CoreDbContexts db)
        {
            _blogPostRepository = blogPostRepository;
            _db = db;
        }
        public async Task<IList<BlogPost>> GetAllBlogPostsAsync(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            //return await _blogPostRepository.GetAllPagedAsync(async query =>
            //{
            //    query = query.OrderByDescending(b => b.StartDateUtc ?? b.CreatedOnUtc);

            //    return query;
            //});
            var query = await _db.BlogPost.ToListAsync();

            return query; 
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
