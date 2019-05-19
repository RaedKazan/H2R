using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace R2H.Controllers
{
    public class LookUpController : Controller
    {

        private readonly ILookUpService _electricCigaretService;

        public LookUpController(ILookUpService electricCigaretService)
        {
            _electricCigaretService = electricCigaretService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}