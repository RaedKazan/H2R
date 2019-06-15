using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using ApplicationService.ViewModels.Customer;
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
                int tst = 0;
                var tmp1 = await _electricCigaretService.GetAllItem(tst);
                //var tmp2 = await _electricCigaretService.GetAllItem(1);
                var model = new ViewAllItemsForCustomers(tmp1);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }


            
        }
    }
}