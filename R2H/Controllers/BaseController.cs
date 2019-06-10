using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R2H.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace R2H.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async  Task<IList<string>>  GetCurrentUserRoles()
        {
            var userId=  _userManager.GetUserId(HttpContext.User);
            var userDetials = await _userManager.FindByIdAsync(userId);
            if (userDetials != null)
                return await _userManager.GetRolesAsync(userDetials);
            else return null;
        }
    }
}