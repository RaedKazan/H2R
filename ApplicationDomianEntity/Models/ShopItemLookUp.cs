using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDomianEntity.Models
{
    public class ShopItemLookUp
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public int Category { get; set; }
        public int Brand { get; set; }
        public string Description { get; set; }
        public ICollection<ShopItem> ShopItemBrand { get; set; }
        public ICollection<ShopItem> ShopItemCategory { get; set; }


    }
}
