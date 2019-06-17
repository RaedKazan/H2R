using ApplicationService;
using ApplicationService.CustomerServices;
using ApplicationService.ViewModels.Card;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using R2H.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R2H.Controllers
{

    public class CustomerController : BaseController
    {
        private readonly IElectricCigaretService _electricCigaretService;
        private readonly ICustomerService _CustomerService;
        private readonly ILogger logger;
        public CustomerController(
            IElectricCigaretService electricCigaretService,
            ILoggerFactory LoggerFactory,
            ICustomerService CustomerService,
            UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _electricCigaretService = electricCigaretService;
            _CustomerService = CustomerService;
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                logger.LogDebug("CustomerController: Start Index [GET]");
                //return View();
                
                var modul = await _electricCigaretService.GetAllItem(0);
                return View(modul);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }


            
        }

        public IActionResult ViewCardInformation()
        {
            var cart = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        public async Task<IActionResult> Buy([FromBody]BuyItemViewModel BuyItemViewModel)
        {
            Product productModel = new Product();
            if (SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                var result= await  _CustomerService.AddToCard(BuyItemViewModel);
                result.Product.UserId = base.GetCurrentUserId();
                cart.Add(new Item { Product = result.Product, Quantity = result.Quantity });
                SystemHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(BuyItemViewModel.ItemId, BuyItemViewModel.JuiceId, BuyItemViewModel.JuiceMangmentId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    var result = await _CustomerService.AddToCard(BuyItemViewModel);
                    result.Product.UserId = base.GetCurrentUserId();
                    cart.Add(new Item { Product = result.Product, Quantity = result.Quantity });
                }
                SystemHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove([FromBody]BuyItemViewModel BuyItemViewModel)
        {
            List<Item> cart = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(BuyItemViewModel.ItemId, BuyItemViewModel.JuiceId, BuyItemViewModel.JuiceMangmentId);
            cart.RemoveAt(index);
            SystemHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private int isExist(int ItemId, int JuiceId, int JuiceMangmentId)
        {
            List<Item> cart = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ItemId.Equals(ItemId))
                {
                    return i;
                }
                if(cart[i].Product.JuiceId.Equals(JuiceId)&& cart[i].Product.JuiceMangmentId.Equals(JuiceMangmentId))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}