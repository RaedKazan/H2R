
using ApplicationService;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace R2H.Controllers
{
    public class JuiceController : Controller
    {

        private readonly IJuiceService _juiceService;
        private readonly ILogger logger;
        private readonly ILookUpService _lookUpService;

        public JuiceController(IJuiceService JuiceService, ILoggerFactory LoggerFactory, ILookUpService LookUpService)
        {
            _juiceService = JuiceService;
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _lookUpService = LookUpService;
        }

        //this view need enehancment
        public async Task<IActionResult> AddLookUp()
        {
            var result = await _lookUpService.AddLookUpForJuice();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLookUp(AddLookUpViewModel AddLookUpViewModel)
        {
            await _lookUpService.CreateLookUpForEjuice(AddLookUpViewModel);
            ViewBag.SuccessMessage = "تم الأضافة بنجاح";
            return View("AddLookUp", await _lookUpService.AddLookUpForJuice());
        }

        //this view need enehancment and validation
        public async Task<IActionResult> AddJuice()
        {
            var result = await _juiceService.AddNewJuice();

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateJuice(AddJuiceViewModel JuiceViewModel)
        {
            try
            {
                logger.LogDebug("Start CreateItem [Post]", JuiceViewModel.ToString());
                if (ModelState.IsValid)
                {
                    var result = await _juiceService.CreateNewJuice(JuiceViewModel);
                    if (result)
                        return RedirectToAction("Index","Home");
                    else
                    {
                        ViewBag.ErrorMassag = "هذا العنصر مدخل مسبقا يجب عليه تعديل نفس العنصر ";
                        return View("AddJuice", await _juiceService.AddNewJuice());
                    }
                }
                else
                {
                    return View("AddJuice", await _juiceService.AddNewJuice());
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                ViewBag.ErrorMassag = "حدث خطاء الرجاء المحاولة مرة اخرى ";
                return View("AddJuice", await _juiceService.AddNewJuice());
            }
        }
        public async Task<IActionResult> NicotinePercentage(int Id)
        {
            var result = await _juiceService.AddNewJuiceWithCategoryId(Id);

            return View("AddJuice", result);
        }

        public async Task<IActionResult> ViewAllItems()
        {
            try
            {
                logger.LogDebug("Start ViewAllItems ", "Type= Juice");
                var modul = await _juiceService.GetAllItem();

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
                var modul = await _juiceService.GetItemById(Id);
                return View(modul);
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
                await _juiceService.DeleteJuice(Id);
                return View(/*modul*/);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(AddJuiceViewModel Model)
        {
            try
            {
                logger.LogDebug("Start GetItemById ", "Id= " + Model.Id);
                await _juiceService.UpdateItemById(Model.Id, Model);
                return View(/*modul*/);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }



    }
}