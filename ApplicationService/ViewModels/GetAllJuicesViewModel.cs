using ApplicationDomianEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationService.ViewModels
{
    public class GetAllJuicesViewModel
    {
        public GetAllJuicesViewModel(IList<JuiceItem> ElectricCigarets)
        {
            this.ElectricCigarets = new List<GetJuiceViewModel>();

            foreach (var item in ElectricCigarets)
            {
                this.ElectricCigarets.Add(
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
        public List<GetJuiceViewModel> ElectricCigarets { get; set; }
    }
}
