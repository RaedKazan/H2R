using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApplicationService
{
    public class ItemMangmentService: IItemMangmentService
    {
        private readonly IRepository<ShopItemMangment> electricCigaretMangment;

        public ItemMangmentService(IRepository<ShopItemMangment> ElectricCigaretMangment)
        {
            electricCigaretMangment = ElectricCigaretMangment;
        }
        public async Task GetAllItemsInventory( int? Type,int? Brand, int? Category)
        {
            var model = new List<ShopItemMangment>();
            if(Type!=0)
            { 
                var result = await electricCigaretMangment.FindAllAsync(c => c.Type == Type);
                model = result.ToList();
            }
            if (Brand != 0)
            {
                var result = await electricCigaretMangment.FindAllAsync(c => c.Brand == Brand);
                model = result.ToList();
            }
            if (Category != 0)
            {
                var result = await electricCigaretMangment.FindAllAsync(c => c.Category == Category);
                model = result.ToList();
            }
        }



    }
}
