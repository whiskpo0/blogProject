using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Blogs;
using Nop.Service.Blogs;
using Nop.Service.Helpers;
using Nop.Service.Seo;
using Nop.Web.Models.Blogs;

namespace Nop.Web.Factories
{
    public class BlogModelFactory : IBlogModelFactory
    {
        private readonly IBlogService _blogService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IUrlRecordService _urlRecordService;

        public BlogModelFactory(IBlogService blogService,
            IDateTimeHelper dateTimeHelper,
            IUrlRecordService urlRecordService)
        {
            _blogService = blogService;
            _dateTimeHelper = dateTimeHelper;
            _urlRecordService = urlRecordService;
        }

        public async Task PrepareBlogPostModelAsync(BlogPostModel model, BlogPost blogPost, bool prepareComments)
        {
            model.Id = blogPost.Id;
            model.MetaTitle = blogPost.MetaTitle;
            model.MetaDescription = blogPost.MetaDescription;
            model.MetaKeywords = blogPost.MetaKeywords;
            model.SeName = await _urlRecordService.GetSeNameAsync(blogPost, blogPost.LanguageId);
            model.Title = blogPost.Title;
            model.Body = blogPost.Body;
            model.BodyOverview = blogPost.BodyOverview;
            //Allow Comments
            //model.CreatedOn = await _dateTimeHelper.ConvertToUserTimeAsync(blogPost.StartDateUtc ?? blogPost.CreatedOnUtc, DateTimeKind.Utc);
            model.Tags = await _blogService.ParseTagsAsync(blogPost);

            //check to see if we want to show blog comments.  

        }
        public async Task<BlogPostListModel> PrepareBlogPostListModelAsync(BlogPagingFilteringModel command)
        {

            var dateFrom = command.GetFromMonth(); 
            var dateTo = command.GetToMonth(); 

            var blogPosts = string.IsNullOrEmpty(command.Tag)
                ? await _blogService.GetAllBlogPostsAsync(dateFrom, dateTo)
                : await _blogService.GetAllBlogPostsByTagAsync(command.Tag);

            var model = new BlogPostListModel()
            {
                BlogPosts = await blogPosts.SelectAwait(async blogPosts =>
                {
                    var blogPostModel = new BlogPostModel();
                    await PrepareBlogPostModelAsync(blogPostModel, blogPosts, false);
                    return blogPostModel;
                }).ToListAsync()     
            };

            return model;
        }
    }
}
