using ApplicationDomianEntity.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationService.ViewModels
{
    public class GetAllElectricCigaretViewModel
    {
        public GetAllElectricCigaretViewModel(IList<ShopItem> ElectricCigarets)
        {
            this.ElectricCigarets = new List<GetElectricCigaretViewModel>();

            foreach (var item in ElectricCigarets)
            {
                this.ElectricCigarets.Add(
                   new GetElectricCigaretViewModel
                   {
                       Id = item.Id,
                       Category = item.CategoryId,
                       Name = item.Name,
                       Description = item.Description,
                       Price = item.Price,
                       Image = item.Image,
                       IsAvilable = item.ElectricCigaretMangment.IsAvilable,
                       CurrentlyCountAvilabil = item.ElectricCigaretMangment.TotalyAvilable,
                       Brand = item.BrandId
                   });
            }
        }
        public List<GetElectricCigaretViewModel> ElectricCigarets { get; set; }
    }
}
