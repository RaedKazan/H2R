using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class ElectricCigaretService : IElectricCigaretService
    {
        private readonly IRepository<ShopItemLookUp> ElectricCigaretLookUpRepository;
        private readonly IRepository<ShopItem> ElectricCigaretRepository;
        private readonly IRepository<ShopItemMangment> ElectricCigaretMangment;

        public ElectricCigaretService(
            IRepository<ShopItem> ElectricCigaretRepository,
            IRepository<ShopItemLookUp> ElectricCigaretLookUpRepository,
            IRepository<ShopItemMangment> ElectricCigaretMangment
           )
        {
            this.ElectricCigaretLookUpRepository = ElectricCigaretLookUpRepository;
            this.ElectricCigaretRepository = ElectricCigaretRepository;
            this.ElectricCigaretMangment = ElectricCigaretMangment;
        }
        public async Task<bool> AddElectricCigaret(AddElectricCigaretViewModel ElectricCigaretViewModel)
        {
            var ElectricCigaret = new ShopItem()
            {
                Description = ElectricCigaretViewModel.Description,
                Image = Encoding.ASCII.GetBytes(ElectricCigaretViewModel.Image.Substring(ElectricCigaretViewModel.Image.IndexOf("64") + 4)),
                Name = ElectricCigaretViewModel.Name,
                SellingPrice = ElectricCigaretViewModel.SelligPrice,
                BuyingPrice = ElectricCigaretViewModel.BuyingPrice,
                TypeId = ElectricCigaretViewModel.TypeId,
                CreatedDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                BrandId = ElectricCigaretViewModel.BrandId.Value,
                CategoryId = ElectricCigaretViewModel.CategoryId.Value,
                IsActive = true
            };

            if (!ElectricCigaretMangment.GetAll().Where(c => c.Type == ElectricCigaretViewModel.TypeId && c.Category == ElectricCigaretViewModel.CategoryId && c.Brand == ElectricCigaretViewModel.BrandId).Any())
            {
                var LookUpId = ElectricCigaretLookUpRepository.Find(c => c.Type == ElectricCigaretViewModel.TypeId && c.Id == ElectricCigaretViewModel.CategoryId);
                var electricCigaret = await ElectricCigaretRepository.AddAsync(ElectricCigaret);
                var model = await ElectricCigaretMangment.AddAsync(new ShopItemMangment
                {
                    IsAvilable = true,
                    TotalyAvilable = ElectricCigaretViewModel.CountToInsert,
                    TotalyInserted = ElectricCigaretViewModel.CountToInsert,
                    TotalySold = 0,
                    Type = ElectricCigaretViewModel.TypeId,
                    Brand = ElectricCigaretViewModel.BrandId.Value,
                    Category = ElectricCigaretViewModel.CategoryId.Value,
                    ElectricCigaretId = electricCigaret.Id

                });
                electricCigaret.ElectricCigaretMangmentId = model.Id;
                ElectricCigaretRepository.Update(electricCigaret, electricCigaret.Id);
                return true;

            }
            else
            {
                return false;

            }
        }
        public async Task DeleteElectricCigaret(int Id)
        {
            var ElectricCigaret = await ElectricCigaretRepository.GetAsync(Id);
            ElectricCigaret.IsActive = false;
            ElectricCigaretRepository.UpdateAsync(ElectricCigaret);
        }
        public async Task<GetAllElectricCigaretViewModel> GetAllItem(int Type=0,int Brand=0 , int Category=0)
        {
            var electricCigarets = await ElectricCigaretRepository.GetAllIncluding(c=>c.ElectricCigaretMangment).Where(c=>c.TypeId==Type).ToListAsync();
            if (Brand != 0)
                electricCigarets.Where(c => c.BrandId == Brand).ToList();
            if (Category != 0)
                electricCigarets.Where(c => c.CategoryId == Category).ToList();

            return new GetAllElectricCigaretViewModel(electricCigarets);
        }
        public async  Task<GetElectricCigaretViewModel> GetItemById(int Id)
        {
            var electricCigaret = await ElectricCigaretRepository.GetAllIncluding(c => c.Category ,x=>x.Brand,a=>a.ElectricCigaretMangment).Where(z=>z.Id==Id).FirstAsync();
            return new GetElectricCigaretViewModel(electricCigaret);
        }
        public async Task<AddElectricCigaretViewModel> GetElectricCigaretLookUps(int TypeId)
        {
            AddElectricCigaretViewModel ElectricCigaretViewModel = new AddElectricCigaretViewModel();
            ElectricCigaretViewModel.TypeId = TypeId;
            var ElectricCigaretLookUp = await ElectricCigaretLookUpRepository.FindAllAsync(c=>c.Type==TypeId);

            ElectricCigaretViewModel.BrandSelectList = ElectricCigaretLookUp.Where(c => c.Type == TypeId && c.Brand != 0).Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();

            ElectricCigaretViewModel.CategorySelectList = ElectricCigaretLookUp.Where(c => c.Type == TypeId && c.Category != 0).Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();
   
            return ElectricCigaretViewModel;
        }
        public async Task UpdateItemById(int Id, AddElectricCigaretViewModel ElectricCigaret)
        {

            var Item = await ElectricCigaretRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.Id == Id).FirstAsync();
                Item.Image = Encoding.ASCII.GetBytes(ElectricCigaret.Image.Substring(ElectricCigaret.Image.IndexOf("64") + 4));
                Item.Name = ElectricCigaret.Name;
                Item.LastModificationDate = DateTime.Now;
                Item.Description = ElectricCigaret.Description;
                Item.BuyingPrice = ElectricCigaret.BuyingPrice;
                Item.SellingPrice = ElectricCigaret.SelligPrice;
                ElectricCigaretRepository.UpdateAsync(Item);
                var electricCigaretMangment = ElectricCigaretMangment.Find(c => c.Id == Item.ElectricCigaretMangmentId);
                electricCigaretMangment.TotalyAvilable = electricCigaretMangment.TotalyAvilable + ElectricCigaret.CountToInsert;
                electricCigaretMangment.TotalyInserted = electricCigaretMangment.TotalyInserted + ElectricCigaret.CountToInsert;
                ElectricCigaretMangment.UpdateAsync(electricCigaretMangment);
        }
    }
}
