using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels.Card;
using ApplicationService.ViewModels.Customer;
using ApplicationService.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<ShopItem> ElectricCigaretRepository;
        private readonly IRepository<JuiceItem> JuiceRepository;
        private readonly ILogger logger;
        public CustomerService(
            IRepository<ShopItem> ElectricCigaretRepository,
            IRepository<JuiceItem> JuiceRepository,
               ILoggerFactory LoggerFactory
           )
        {
            this.ElectricCigaretRepository = ElectricCigaretRepository;
            this.JuiceRepository = JuiceRepository;
            this.logger = LoggerFactory.CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public async Task<Item> AddToCard(BuyItemViewModel Model)
        {
            if (Model.ItemId > 0)
            {
                return await AddItemToCard(Model.ItemId, Model.Quantity,Model.UserId);
            }
            else
            {
                return await AddJuiceToCard(Model.JuiceId, Model.JuiceMangmentId, Model.Quantity, Model.UserId);
            }

        }

        public async Task<ViewAllItemsForCustomers> ViewCard(List<Item> Model)
        {

            List<ShopItem> getElectricCigaretViewModel = new List<ShopItem>();
            List<ShopItem> getVapeViewModel = new List<ShopItem>();
            List<JuiceItem> getJuiceItemViewModel = new List<JuiceItem>();

            foreach (var item in Model)
            {
                // if the item is vape or ECigrate
                if (item.Product.ItemId != 0 && item.Product.JuiceMangmentId == 0)
                {
                    var eCigrateModel = await ElectricCigaretRepository.GetAllIncluding(c => c.Category, x => x.Brand, a => a.ElectricCigaretMangment).Where(z => z.Id == item.Product.ItemId).FirstAsync();
                    if (eCigrateModel.TypeId == (int)DomainValues.Vape)
                    {
                        getVapeViewModel.Add(eCigrateModel);
                    }
                    else
                    {
                        getElectricCigaretViewModel.Add(eCigrateModel);
                    }
                }
                else
                {
                    getJuiceItemViewModel.Add(await JuiceRepository.GetAllIncluding(c => c.Category, x => x.Brand, a => a.ElectricCigaretMangment).Where(z => z.Id == item.Product.JuiceId && z.ElectricCigaretMangmentId == item.Product.JuiceMangmentId).FirstAsync());
                }
            }

            return new ViewAllItemsForCustomers(getVapeViewModel, getElectricCigaretViewModel, getJuiceItemViewModel);

        }


        public async Task<ViewAllItemsForCustomers> GetAllItems()
        {
            try
            {
                var getVapeViewModel = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.IsActive == true && (c.TypeId == (int)DomainValues.Vape)).Take(10).ToListAsync();
                var getElectricCigaretViewModel = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.IsActive == true && (c.TypeId == (int)DomainValues.ECigaret)).Take(10).ToListAsync();
                var getJuiceItemViewModel = await JuiceRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.IsActive == true).Take(10).ToListAsync();
                return new ViewAllItemsForCustomers(getVapeViewModel, getElectricCigaretViewModel, getJuiceItemViewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }


        private async Task<Item> AddItemToCard(int ItemId, int Quantity, string UserId)
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
                        Price = result.SellingPrice.Value,
                        UserId= UserId,
                        // note this line should be removed later on the image size is to large fot the session 
                        Photo=result.Image
                    },
                    Quantity = Quantity
                };
            }
            else
            {
                throw new Exception(ErrorEnum.TheQuantityIsNotEnough.ToString());
            }
        }

        private async Task<Item> AddJuiceToCard(int JuiceId, int JuiceMangmentId, int Quantity,string UserId)
        {
            var result = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.Id == JuiceId).FirstOrDefaultAsync();
            if (result.ElectricCigaretMangment.Where(c => c.Id == JuiceMangmentId).FirstOrDefault().TotalyAvilable > Quantity)
            {
                return new Item()
                {
                    Product = new Product
                    {
                        JuiceId = result.Id,
                        Name = result.Name,
                        JuiceMangmentId = JuiceMangmentId,
                        Price = result.SellingPrice.Value,
                        UserId=UserId,
                        Photo=result.Image
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
