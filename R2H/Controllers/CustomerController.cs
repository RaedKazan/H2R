using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace R2H.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly IElectricCigaretService _electricCigaretService;
        private readonly ILogger logger;
        public CustomerController(IElectricCigaretService electricCigaretService, ILoggerFactory LoggerFactory)
        {
            _electricCigaretService = electricCigaretService;
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                logger.LogDebug("CustomerController: Start Index [GET]");
                //return View();
                
                var modul = await _electricCigaretService.GetAllItem(0);
                return View(modul);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }


            
        }
    }
}