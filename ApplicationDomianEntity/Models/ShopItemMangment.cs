using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDomianEntity.Models
{
    public class ShopItemMangment
    {   [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public int Brand { get; set; }
        public int Category { get; set; }
        public int? TotalyInserted { get; set; }
        public int TotalySold { get; set; }
        public int? TotalyAvilable { get; set; }
        public bool IsAvilable { get; set; }
        public ShopItem ElectricCigaret { get; set; }
        public int? ElectricCigaretId { get; set; }
        public int? JuiceId { get; set; }
        public JuiceItem JuiceItem { get; set; }


    }
}
