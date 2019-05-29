using ApplicationDomianEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "النوع")]

        public int Category { get; set; }
        [Display(Name = "النوعية")]

        public int Brand { get; set; }
        public string CategoryText { get; set; }
        public string BrandText { get; set; }
        [Display(Name = "الأسم")]

        public string Name { get; set; }
        [Display(Name = "الوصف")]

        public string Description { get; set; }
        public int? CurrentlyCountAvilabil { get; set; }
        [Display(Name = "السعر")]

        public Double? Price { get; set; }
        [Display(Name = "الصورة")]

        public byte[] Image { get; set; }
        [Display(Name = "متوفر")]
        public bool? IsAvilable { get; set; }
        public string IsAvilableText { get; set; }

    


    }
}
