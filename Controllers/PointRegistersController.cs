using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopTemplateAPI.Controllers.FrequentlyUsed;
using ShopTemplateAPI.Models;
using ShopTemplateAPI.StaticValues;
using System.Collections.Generic;
using System.Linq;

namespace ShopTemplateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointRegistersController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly ILogger<PointRegistersController> _logger;

        public PointRegistersController(ShopContext _context, ILogger<PointRegistersController> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        /// <summary>
        /// Возвращает записи баллов, хоть как-то связанные с пользователем
        /// </summary>
        // GET: api/PointRegisters/3
        [Route("{_page}")]
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<PointRegister>> GetPointRegisters(int _page)
        {
            var mySelf = Functions.identityToUser(User.Identity, _context);

            IQueryable<PointRegister> pointRegisters = _context.PointRegister.Where(pr => pr.UserId == mySelf.UserId)
                                                        .OrderByDescending(pr => pr.CreatedDate);
            pointRegisters = Functions.GetPageRange(pointRegisters, _page, PageLengths.POINTREGISTER_LENGTH);

            if (!pointRegisters.Any())
            {
                return NotFound();
            }

            var result = pointRegisters.ToList();

            return result;
        }
    }
}
