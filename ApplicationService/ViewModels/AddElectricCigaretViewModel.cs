using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationService.ViewModels
{
    public class AddElectricCigaretViewModel
    {

      
        public List<SelectListItem> TypeSelectList { get; set; }
     
        public List<SelectListItem> BrandSelectList { get; set; }
        [Display(Name = "النوع")]
        [Required(ErrorMessage = "الرجاء ادخال النوع")]
        [Range(1, 30, ErrorMessage = "الرجاء ادخال النوع")]
        public int Type { get; set; }
        [Display(Name = "النوعية")]
        [Required(ErrorMessage = "الرجاء ادخال النوعية")]
        [Range(1, 30, ErrorMessage = "الرجاء ادخال النوعية")]
        public int Brand { get; set; }
        public string Name { get; set; }
        [Display(Name = "الوصف")]
        public string Description { get; set; }
        [Display(Name = "العدد ")]
        [Required(ErrorMessage = "الرجاء ادخال العدد ")]
        [Range(1, 30, ErrorMessage = "العدد المسموح من 1 الى 50")]
        public int? CountToInsert { get; set; }
        [Display(Name = "السعر")]
        [Required(ErrorMessage = "الرجاء ادخال السعر")]
        public Double? Price { get; set; }
        [Display(Name = "الصورة")]
        [Required(ErrorMessage = "الرجاء ادخال الصورة")]
        public byte[] Image { get; set; }

    }
}
