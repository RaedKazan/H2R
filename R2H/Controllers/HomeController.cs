using ApplicationDataAccess.ApplicationRepository;
using ApplicationDataAccess.ApplicationUOF;
using ApplicationDomianEntity.Models;
using ApplicationService;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using R2H.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace R2H.Controllers
{
    public class HomeController : Controller
    {
        private readonly IElectricCigaretService _electricCigaretService;
        private readonly ILogger logger;

        public HomeController(IElectricCigaretService electricCigaretService, ILoggerFactory LoggerFactory)
        {
            _electricCigaretService = electricCigaretService;
            logger= LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<IActionResult> AddItem()
        {
            try
            {
                logger.LogDebug("Start Add Item-[Get]");
                var modul = await _electricCigaretService.GetElectricCigaretLookUps();
                return View(modul);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");

            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatItem(AddElectricCigaretViewModel Model)
        {
            try
            {
                logger.LogDebug("Start CreateItem-[Post]");
                int y=2;
                int x = 1 / y;
                if (ModelState.IsValid)
                {
                    var modul = await _electricCigaretService.AddElectricCigaret(Model);
                    if (modul)
                        return RedirectToAction("Index");
                    else
                    {
                        ViewBag.ErrorMassag = "هذا العنصر مدخل مسبقا يجب عليه تعديل نفس العنصر ";
                        return View("AddItem", await _electricCigaretService.GetElectricCigaretLookUps());
                    }
                }
                else
                {
                    return View("AddItem", Model);

                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
