using ApplicationDomianEntity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationService.ViewModels
{
    public class AddElectricCigaretViewModel
    {

      
        public List<SelectListItem> CategorySelectList { get; set; }
     
        public List<SelectListItem> BrandSelectList { get; set; }
        [Display(Name = "النوع")]
        [Required(ErrorMessage = "الرجاء ادخال النوع")]
        [Range(1, 30, ErrorMessage = "الرجاء ادخال النوع")]
        public int? CategoryId { get; set; }
        [Display(Name = "النوعية")]
        [Required(ErrorMessage = "الرجاء ادخال النوعية")]
        [Range(1, 30, ErrorMessage = "الرجاء ادخال النوعية")]
        public int? BrandId { get; set; }
        public int TypeId { get; set; }
        [Display(Name = "الأسم")]
        [Required(ErrorMessage = "الرجاء ادخال الأسم")]
        public string Name { get; set; }
        [Display(Name = "الوصف")]
        [Required(ErrorMessage = "الرجاء ادخال الوصف")]

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
        public string Image { get; set; }

    }
}
