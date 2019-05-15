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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IElectricCigaretService _electricCigaretService;

        public HomeController(IElectricCigaretService electricCigaretService, IUnitOfWork unitOfWork)
        {
            _electricCigaretService = electricCigaretService;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<IActionResult> AddItem()
        {
             var  modul= await _electricCigaretService.GetElectricCigaretLookUps();
            return View(modul);
        }
        [HttpPost]
        public async Task<IActionResult> CreatItem(AddElectricCigaretViewModel Obj)
        {
            var modul = await _electricCigaretService.GetElectricCigaretLookUps();
            return View("AddItem",modul);
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
