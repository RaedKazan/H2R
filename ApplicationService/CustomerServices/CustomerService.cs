using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels.Card;
using ApplicationService.ViewModels.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.CustomerServices
{
   public class CustomerService : ICustomerService
    {
        private readonly IRepository<ShopItem> ElectricCigaretRepository;
        private readonly IRepository<JuiceItem> JuiceItemRepository;
        private readonly ILogger logger;
        public CustomerService(
            IRepository<ShopItem> ElectricCigaretRepository,
            IRepository<JuiceItem> JuiceItemRepository,
               ILoggerFactory LoggerFactory
           )
        {
            this.ElectricCigaretRepository = ElectricCigaretRepository;
            this.JuiceItemRepository = JuiceItemRepository;
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

        public async Task<ViewAllItemsForCustomers> GetAllItems()
        {
            try
            {
                var vapes = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.IsActive == true && (c.TypeId == (int)DomainValues.Vape)).Take(10).ToListAsync();
                var eCigrete = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.IsActive == true && (c.TypeId == (int)DomainValues.ECigaret)).Take(10).ToListAsync();
                var juice = await JuiceItemRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.IsActive == true).Take(10).ToListAsync();
                return new ViewAllItemsForCustomers(vapes, eCigrete, juice);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
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
