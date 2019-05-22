using ApplicationDomianEntity.Models;
using System;
using System.Collections.Generic;

namespace ApplicationService.ViewModels
{
    public class GetElectricCigaretViewModel
    {

        public GetElectricCigaretViewModel(ShopItem Model)
        {
            this.Id = Model.Id;
            this.Category = Model.CategoryId;
            this.BrandText = Model.Brand.Description;
            this.CategoryText = Model.Category.Description;
            this.Brand = Model.BrandId;
            this.Name = Model.Name;
            this.Description = Model.Description;
            this.Price = Model.Price;
            this.Image = Model.Image;
            this.IsAvilable = Model.ElectricCigaretMangment.IsAvilable;
            this.CurrentlyCountAvilabil = Model.ElectricCigaretMangment.TotalyAvilable;
        }
        public GetElectricCigaretViewModel()
        {
        }
        public int Id { get; set; }
        public int Category { get; set; }
        public int Brand { get; set; }
        public string CategoryText { get; set; }
        public string BrandText { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CurrentlyCountAvilabil { get; set; }
        public Double? Price { get; set; }
        public byte[] Image { get; set; }

        public bool? IsAvilable { get; set; }
       


    }
}
