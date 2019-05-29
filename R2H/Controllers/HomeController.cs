using ApplicationService;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using R2H.Models;
using System;
using System.Data;
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
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        }
        public IActionResult Index()
        {
            try
            {
                logger.LogDebug("Start Index [GET]");
                return View();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        public async Task<IActionResult> AddItem(int Id)
        {
            try
            {
                logger.LogDebug("Starting AddItem", "Id=" + Id);
                var modul = await _electricCigaretService.GetElectricCigaretLookUps(Id);
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
                logger.LogDebug("Start CreateItem [Post]", Model.ToString());
                if (ModelState.IsValid)
                {
                    var result = await _electricCigaretService.AddElectricCigaret(Model);
                    if (result)
                        return RedirectToAction("Index");
                    else
                    {
                        ViewBag.ErrorMassag = "هذا العنصر مدخل مسبقا يجب عليه تعديل نفس العنصر ";
                        return View("AddItem", await _electricCigaretService.GetElectricCigaretLookUps(Model.TypeId));
                    }
                }
                else
                {
                    return View("AddItem", await _electricCigaretService.GetElectricCigaretLookUps(Model.TypeId));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                ViewBag.ErrorMassag = "حدث خطاء الرجاء المحاولة مرة اخرى ";
                return View("AddItem", await _electricCigaretService.GetElectricCigaretLookUps(Model.TypeId));
            }
        }
        //please rename this method
        public IActionResult CreateItem()
        {
            try
            {
                logger.LogDebug("Start CreateItem [GET]");
                return View();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
         //please rename this method
        public IActionResult ViewItems()
        {
            try
            {
                logger.LogDebug("Start View [GET]");
                return View();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        public async Task<IActionResult> ViewAllItems(int Id)
        {
            try
            {
                logger.LogDebug("Start ViewAllItems ", "Id= " + Id);
                var modul = await _electricCigaretService.GetAllItem(Id);
                return View(modul);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetItemById(int Id)
        {
            try
            {
                logger.LogDebug("Start GetItemById ", "Id= " + Id);
                var modul = await _electricCigaretService.GetItemById(Id);
                return View(modul);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        // View Must be added
        [HttpPut]
        public async Task<IActionResult> UpdateItem(AddElectricCigaretViewModel Model)
        {
            try
            {
                logger.LogDebug("Start GetItemById ", "Id= " + Model.Id);
                await _electricCigaretService.UpdateItemById(Model.Id, Model);
                return View(/*modul*/);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        //Massage need to be added and redirect to Index
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int Id)
        {
            try
            {
                logger.LogDebug("Start DeleteItem  ", "Id= " + Id);
                await _electricCigaretService.DeleteElectricCigaret(Id);
                return View(/*modul*/);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }
        [Authorize(Roles  = "Admin")]
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
