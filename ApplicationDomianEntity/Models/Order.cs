using R2H.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomianEntity.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int OrderId { get; set; }
        public int? JuiceItemId { get; set; }
        public int? ShopItemId { get; set; }
        public int ItemMangmentId { get; set; }
        public int Quantity { get; set; }
        public int Date { get; set; }
        public bool IsPending { get; set; }
        public bool IsCanceled { get; set; }
        public JuiceItem JuiceItem { get; set; }
        public ShopItem ShopItem { get; set; }
        public ApplicationUser ApplicationUser{ get; set; }


    }
}
