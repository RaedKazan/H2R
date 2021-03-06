﻿using ApplicationService;
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

        // to do add View w
        public async Task<IActionResult> AddLookUp(int Id)
        {
            var model= await _electricCigaretService.AddLookUp(Id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLookUp(AddLookUpViewModel AddLookUpViewModel)
            {
            var model = await _electricCigaretService.CreateLookUpForItems(AddLookUpViewModel);
            ViewBag.SuccessMessage = "تم الأضافة بنجاح";
            return View("AddLookUp", await _electricCigaretService.AddLookUp(AddLookUpViewModel.TypeId));
        }
    }
}