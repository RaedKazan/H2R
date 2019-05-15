using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomianEntity.Models
{
    public class ShopItemMangment
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Brand { get; set; }
        public int? TotalyInserted { get; set; }
        public int TotalySold { get; set; }
        public int? TotalyAvilable { get; set; }
        public bool IsAvilable { get; set; }
        public ShopItem ElectricCigaret { get; set; }
    }
}
