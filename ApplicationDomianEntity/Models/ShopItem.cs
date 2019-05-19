using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDomianEntity.Models
{
    public class ShopItem
    {

        [Key]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public ShopItemLookUp Brand { get; set; }
        public ShopItemLookUp Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double? Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public byte[] Image { get; set; }
        public ShopItemMangment ElectricCigaretMangment { get; set; }
        public int ElectricCigaretMangmentId { get; set; }
        public bool IsActive { get; set; }


    }
}
