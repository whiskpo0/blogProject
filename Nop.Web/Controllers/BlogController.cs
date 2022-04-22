using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogModelFactory _blogModelFactory;

        public BlogController(IBlogModelFactory blogModelFactory)
        {
            _blogModelFactory = blogModelFactory;
        }


        public virtual async Task<IActionResult> List(BlogPagingFilteringModel command)
        {
            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);

            return View("List", model); 
        }
    }
}
