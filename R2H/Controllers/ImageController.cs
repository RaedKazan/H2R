using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

// this module should be implemented to add multiple images for any item

namespace R2H.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateAsync(Image img, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot",
                            file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // here service should be called to updated the table

                return Ok();
            }
            return View(img);
        }
    }
}

public partial class Image
{
    public int ID { get; set; }
    public string ImagePath { get; set; }
}