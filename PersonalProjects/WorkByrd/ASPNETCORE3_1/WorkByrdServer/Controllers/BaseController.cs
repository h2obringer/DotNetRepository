using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;

namespace WorkByrdServer.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly IWorkByrdDbLogger _logger;
        
        public BaseController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IWorkByrdDbLogger dbLogger)
        {
            _context = context;
            _userManager = userManager;
            _logger = dbLogger;
            if (string.IsNullOrWhiteSpace(_context.UserID))
            {
                _context.UserID = _userManager.GetUserId(httpContextAccessor.HttpContext.User);
            }
        }
    }
}
