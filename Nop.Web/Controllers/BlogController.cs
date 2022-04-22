using Microsoft.AspNetCore.Mvc;
using Nop.Data.DbContexts;
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
        private readonly CoreDbContexts _db;

        public BlogController(CoreDbContexts db,
            IBlogModelFactory blogModelFactory) 
        {
            _db = db;
            _blogModelFactory = blogModelFactory;
        }


        public virtual async Task<IActionResult> List(BlogPagingFilteringModel command)
        {
            //var model = await _db.BlogPost.ToListAsync(); 
            
            var model = await _blogModelFactory.PrepareBlogPostListModelAsync(command);


            return View("List", model); 
        }
    }
}
