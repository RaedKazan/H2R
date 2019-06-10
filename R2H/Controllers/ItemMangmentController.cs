using ApplicationService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace R2H.Controllers
{
    public class ItemMangmentController : Controller
    {

        private readonly IItemMangmentService _itemMangmentService;
        public ItemMangmentController(IItemMangmentService ItemMangmentService)
        {
            _itemMangmentService = ItemMangmentService;
        }
        public async Task<IActionResult> Index()
        {
            await _itemMangmentService.GetAllItemsInventory();

            return View();
        }
    }
}