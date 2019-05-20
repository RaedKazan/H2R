using ApplicationService;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace R2H.Controllers
{
    public class LookUpController : Controller
    {

        private readonly ILookUpService _electricCigaretService;

        public LookUpController(ILookUpService electricCigaretService)
        {
            _electricCigaretService = electricCigaretService;
        }


        // to do add View 
        public async Task<IActionResult> AddLookUp(int Id)
        {
            var model= await _electricCigaretService.AddLookUp(Id);
            return View(model);
        }

        public async Task<IActionResult> CreateLookUp(AddLookUpViewModel AddLookUpViewModel)
        {
            var model = await _electricCigaretService.CreateLookUp(AddLookUpViewModel);
            return View(model);
        }
    }
}