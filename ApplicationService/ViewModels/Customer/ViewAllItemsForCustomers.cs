using ApplicationDomianEntity.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationService.ViewModels.Customer
{
    public class ViewAllItemsForCustomers
    {
        public ViewAllItemsForCustomers(IList<ShopItem> ElectricCigarets, IList<ShopItem> VapesList, IList<JuiceItem> JuicesList)
        {
            foreach (var item in ElectricCigarets)
            {
                this.ElectricCigarets.Add(
                   new GetElectricCigaretViewModel
                   {
                       Id = item.Id,
                       Category = item.CategoryId,
                       Name = item.Name,
                       Description = item.Description,
                       SellingPrice = item.SellingPrice,
                       BuyingPrice = item.BuyingPrice,
                       Image = item.Image,
                       IsAvilable = item.ElectricCigaretMangment.FirstOrDefault().IsAvilable,
                       CurrentlyCountAvilabil = item.ElectricCigaretMangment.FirstOrDefault().TotalyAvilable,
                       Brand = item.BrandId
                   });
            }

            foreach (var item in VapesList)
            {
                this.Vapes.Add(
                   new GetElectricCigaretViewModel
                   {
                       Id = item.Id,
                       Category = item.CategoryId,
                       Name = item.Name,
                       Description = item.Description,
                       SellingPrice = item.SellingPrice,
                       BuyingPrice = item.BuyingPrice,
                       Image = item.Image,
                       IsAvilable = item.ElectricCigaretMangment.FirstOrDefault().IsAvilable,
                       CurrentlyCountAvilabil = item.ElectricCigaretMangment.FirstOrDefault().TotalyAvilable,
                       Brand = item.BrandId
                   });
            }

            foreach (var item in JuicesList)
            {
                this.Juices.Add(
                   new GetJuiceViewModel
                   {
                       Id = item.Id,
                       Category = item.CategoryId,
                       Name = item.Name,
                       Description = item.Description,
                       SellingPrice = item.SellingPrice,
                       BuyingPrice = item.BuyingPrice,
                       Image = item.Image,
                       IsAvilable = item.ElectricCigaretMangment.FirstOrDefault().IsAvilable,
                       CurrentlyCountAvilabil = item.ElectricCigaretMangment.FirstOrDefault().TotalyAvilable,
                       Brand = item.BrandId
                   });
            }
        }
        public ViewAllItemsForCustomers()
        {
        }

        public List<GetElectricCigaretViewModel> ElectricCigarets { get; set; }
        public List<GetElectricCigaretViewModel> Vapes { get; set; }
        public List<GetJuiceViewModel> Juices { get; set; }

    }
}
