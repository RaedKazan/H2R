

using R2H.Models;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDomianEntity.Models
{
    public class WishList
    {    [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ShopItemId { get; set; }
        public int JuiceItemId { get; set; }
        public int Count { get; set; }
        public JuiceItem JuiceItem { get; set; }
        public ShopItem ShopItem { get; set; }
        public ApplicationUser User { get; set; }

        

    }
}
