using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopTemplateAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopTemplateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ShopContext _context, ILogger<CategoriesController> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        // GET: api/Categories
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            IQueryable<Category> categories = _context.Category.Include(cat => cat.ChildCategories)
                                                                .Include(cat => cat.Products)
                                                                .Where(cat => cat.ParentCategoryId == null);

            if (!categories.Any())
            {
                return NotFound();
            }

            var result = categories.ToList();

            return result;
        }

        // GET: api/Categories/2
        [Authorize]
        [HttpGet("{_parentCategoryId}")]
        public ActionResult<IEnumerable<Category>> Get(int _parentCategoryId)
        {
            IQueryable<Category> categories = _context.Category.Include(cat => cat.ChildCategories)
                                                                .Include(cat => cat.Products)
                                                                .Where(cat => cat.ParentCategoryId == _parentCategoryId);

            if (!categories.Any()) 
            {
                return NotFound();
            }

            var result = categories.ToList();

            return result;
        }
    }
}
