using ApplicationDomianEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationService.ViewModels
{
    public class GetAllJuicesViewModel
    {
        public GetAllJuicesViewModel(IList<JuiceItem> JuiceList)
        {
            this.Juices = new List<GetJuiceViewModel>();

            foreach (var item in JuiceList)
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
        public List<GetJuiceViewModel> Juices { get; set; }
    }
}
