using ApplicationDataAccess.ApplicationRepository;
using ApplicationDataAccess.ApplicationUOF;
using ApplicationDomianEntity.Models;
using ApplicationService;
using Microsoft.AspNetCore.Mvc;
using R2H.Models;
using System.Diagnostics;

namespace R2H.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Class1> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserService _service;

        public HomeController(UserService service, IRepository<Class1> repository, IUnitOfWork unitOfWork)
        {
            _service = service;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            _service.Hello();
            return View();
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
