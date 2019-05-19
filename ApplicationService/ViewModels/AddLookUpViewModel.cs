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
        public int? Category { get; set; }
        [Display(Name = "النوعية")]
        public int? Brand { get; set; }
        [Display(Name = "الوصف")]
        public string Description { get; set; }
        public List<SelectListItem> TypeSelectList { get; set; }

    }
}
