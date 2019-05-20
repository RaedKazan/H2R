using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationService.ViewModels
{
    public class AddLookUpViewModel
    {
        [Display(Name = "الصنف")]
        public int TypeId { get; set; }
        [Display(Name = "النوع")]
        public bool? Category { get; set; }
        [Display(Name = "النوعية")]
        public bool? Brand { get; set; }
        [Display(Name = "الوصف")]
        [Required(ErrorMessage = "الرجاء ادخال الوصف")]
        public string Description { get; set; }

    }
}
