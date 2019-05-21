using ApplicationDataAccess.ApplicationRepository;
using ApplicationDataAccess.ApplicationUOF;
using ApplicationDomianEntity.Models;
using ApplicationService;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using R2H.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace R2H.Controllers
{
    public class HomeController : Controller
    {
        private readonly IElectricCigaretService _electricCigaretService;
        public HomeController(IElectricCigaretService electricCigaretService)
        {
            _electricCigaretService = electricCigaretService;
        }
        public IActionResult Index()
        {
            return View();
        }
       public async Task<IActionResult> AddItem(int Id)
        {
             var  modul= await _electricCigaretService.GetElectricCigaretLookUps(Id);
             return View(modul);
        }
        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatItem(AddElectricCigaretViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var modul = await _electricCigaretService.AddElectricCigaret(Model);
                if(modul)
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

        // to do add view
        public async Task<IActionResult> ViewAllItems(int Id )
        {
            var modul = await _electricCigaretService.GetAllItem(Id);
            return View(modul);
        }
        // to do add view
        public async Task<IActionResult> GetItemById(int Id)
        {
            var modul = await _electricCigaretService.GetItemById(Id);
            return View(modul);
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
