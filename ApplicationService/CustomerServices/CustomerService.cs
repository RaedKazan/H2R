using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels.Card;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<ShopItem> ElectricCigaretRepository;
        private readonly IRepository<JuiceItem> JuiceItemRepository;

        public CustomerService(
            IRepository<ShopItem> ElectricCigaretRepository,
            IRepository<JuiceItem> JuiceItemRepository
           )
        {
            this.ElectricCigaretRepository = ElectricCigaretRepository;
            this.JuiceItemRepository = JuiceItemRepository;
        }

        public async Task<Item> AddToCard(BuyItemViewModel Model)
        {
            if (Model.ItemId > 0)
            {
                return await AddItemToCard(Model.ItemId, Model.Quantity);
            }
            else
            {
                return await AddJuiceToCard(Model.JuiceId, Model.JuiceMangmentId, Model.Quantity);
            }

        }

        private async Task<Item> AddItemToCard(int ItemId, int Quantity)
        {
            var result = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.Id == ItemId).FirstOrDefaultAsync();
            if (result.ElectricCigaretMangment.FirstOrDefault().TotalyAvilable > Quantity)
            {
                return new Item()
                {
                    Product = new Product
                    {
                        ItemId = result.Id,
                        Name = result.Name,
                        Price = result.Id
                    },
                    Quantity = Quantity
                };
            }
            else
            {
                throw new Exception(ErrorEnum.TheQuantityIsNotEnough.ToString());
            }
        }

        private async Task<Item> AddJuiceToCard(int JuiceId, int JuiceMangmentId, int Quantity)
        {
            var result = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.Id == JuiceId).FirstOrDefaultAsync();
            if (result.ElectricCigaretMangment.Where(c => c.Id == JuiceMangmentId).FirstOrDefault().TotalyAvilable > Quantity)
            {
                return new Item()
                {
                    Product = new Product
                    {
                        ItemId = result.Id,
                        Name = result.Name,
                        JuiceMangmentId = JuiceMangmentId,
                        Price = result.Id
                    },
                    Quantity = Quantity
                };
            }
            else
            {
                throw new Exception(ErrorEnum.TheQuantityIsNotEnough.ToString());
            }
        }
    }
}
