using ApplicationService;
using ApplicationService.CustomerServices;
using ApplicationService.Orders;
using ApplicationService.ViewModels.Card;
using ApplicationService.ViewModels.Customer;
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
        private readonly IJuiceService _juiceService;
        private readonly ICustomerService _CustomerService;
        private readonly IOrderService _orderService;
        
        private readonly ILogger logger;

        public CustomerController(
            IElectricCigaretService electricCigaretService,
            ILoggerFactory LoggerFactory,
            ICustomerService customerService,
            IOrderService orderService,
            UserManager<ApplicationUser> userManager,
            IJuiceService juiceService) : base(userManager)
        {
            _electricCigaretService = electricCigaretService;
            _CustomerService = customerService;
            _juiceService = juiceService;
            _orderService = orderService;
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
              
                logger.LogDebug("CustomerController: Start Index [GET]");
                var Items = await _CustomerService.GetAllItems();
                return View(Items);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");
            }
        }

        // this view need to be changed 
        public async Task<IActionResult> ViewItemDetails(int id)
        {
            try
            {
                logger.LogDebug("Start ViewItemDetails ", "Id= " + id);
                var item = await _electricCigaretService.GetItemById(id);
                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");

            }
        }
        // this view need to be changed 
        public async Task<IActionResult> ViewJuiceDetails(int id)
        {
            try
            {
                logger.LogDebug("Start ViewItemDetails ", "Id= " + id);
                var item = await _juiceService.GetItemById(id);
                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return RedirectToAction("Error");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Buy([FromBody]BuyItemViewModel BuyItemViewModel)
        {
            Product productModel = new Product();
            BuyItemViewModel.UserId = base.GetCurrentUserId();

            //if (string.IsNullOrEmpty(base.GetCurrentUserId()))
            //  return Forbid();


            if (SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                var result = await _CustomerService.AddToCard(BuyItemViewModel);
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
            return Ok();
        }
        [HttpPost]
        public IActionResult Remove([FromBody]BuyItemViewModel BuyItemViewModel)
        {
            try
            {
                logger.LogDebug("Start Remove ");
                List<Item> cart = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(BuyItemViewModel.ItemId, BuyItemViewModel.JuiceId, BuyItemViewModel.JuiceMangmentId);
                cart.RemoveAt(index);
                SystemHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();

            }
        }
        private int isExist(int ItemId, int JuiceId, int JuiceMangmentId)
        {
            List<Item> cart = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ItemId.Equals(ItemId) && ItemId!=0)
                {
                    return i;
                }
                if (cart[i].Product.JuiceId.Equals(JuiceId) && cart[i].Product.JuiceMangmentId.Equals(JuiceMangmentId) && JuiceMangmentId!=0&& JuiceId!=0)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult ViewAllSelectedItems()
        {
            var items = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View(items);
        }
        [HttpPost]
        public async  Task<IActionResult> ConfirmOrder([FromBody]Order Order)
        {
            var items = SystemHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            await _orderService.AddOrder(items);
            // return to home page with details about the the order and so
            return View(items);
        }
    }
}