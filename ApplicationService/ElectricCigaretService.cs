using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Price = ElectricCigaretViewModel.Price,
                TypeId = ElectricCigaretViewModel.TypeId,
                CreatedDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                BrandId = ElectricCigaretViewModel.BrandId.Value,
                CategoryId = ElectricCigaretViewModel.CategoryId.Value,
                IsActive = true
            };

            if (!ElectricCigaretMangment.GetAll().Where(c => c.Type == ElectricCigaretViewModel.TypeId && c.Brand == ElectricCigaretViewModel.BrandId).Any())
            {
                var model = await ElectricCigaretMangment.AddAsync(new ShopItemMangment
                {
                    IsAvilable = true,
                    TotalyAvilable = ElectricCigaretViewModel.CountToInsert,
                    TotalyInserted = ElectricCigaretViewModel.CountToInsert,
                    TotalySold = 0,
                    Type = ElectricCigaretViewModel.TypeId,
                    Brand = ElectricCigaretViewModel.BrandId.Value,
                    Category = ElectricCigaretViewModel.TypeId
                });
                ElectricCigaret.ElectricCigaretMangmentId = model.Id;
                await ElectricCigaretRepository.AddAsync(ElectricCigaret);
                return true;

            }
            else
            {
                return false;
            }
            //else
            //{
            //    var model = ElectricCigaretMangment.GetAll().Where(c => c.Type == ElectricCigaretViewModel.Type && c.Brand == ElectricCigaretViewModel.Brand).First();
            //    ElectricCigaretMangment.UpdateAsync(new ApplicationDomianEntity.Models.ShopItemMangment
            //    {
            //        Id = model.Id,
            //        IsAvilable = true,
            //        TotalyAvilable = model.TotalyAvilable + ElectricCigaretViewModel.CountToInsert,
            //        TotalyInserted = ElectricCigaretViewModel.CountToInsert + model.TotalyInserted,
            //        Type = ElectricCigaretViewModel.Type,
            //        Brand = ElectricCigaretViewModel.Brand,
            //        TotalySold = model.TotalySold
            //    });
            //    ElectricCigaret.ElectricCigaretMangmentId = model.Id;
            //    await ElectricCigaretRepository.AddAsync(ElectricCigaret);
            //}


        }
        public async Task DeleteElectricCigaret(int Id)
        {
            var ElectricCigaret = await ElectricCigaretRepository.GetAsync(Id);
            ElectricCigaret.IsActive = false;
            ElectricCigaretRepository.UpdateAsync(ElectricCigaret);
        }
        public async Task<GetAllElectricCigaretViewModel> GetAllElectricCigaret()
        {
            var electricCigarets = await ElectricCigaretRepository.GetAllAsync();
            return new GetAllElectricCigaretViewModel(electricCigarets);
        }
        public async Task<GetElectricCigaretViewModel> GetElectricCigaretById(int Id)
        {
            var electricCigaret = await ElectricCigaretRepository.GetAsync(Id);
            return new GetElectricCigaretViewModel(electricCigaret);
        }

        public async Task<AddElectricCigaretViewModel> GetElectricCigaretLookUps(int TypeId)
        {
            AddElectricCigaretViewModel ElectricCigaretViewModel = new AddElectricCigaretViewModel();
            ElectricCigaretViewModel.TypeId = TypeId;
            var ElectricCigaretLookUp = await ElectricCigaretLookUpRepository.GetAllAsync();

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
        public async Task UpdateElectricCigaret(int Id, AddElectricCigaretViewModel ElectricCigaret)
        {
            var ECigaret = await ElectricCigaretRepository.GetAsync(Id);


            throw new System.NotImplementedException();
        }
    }
}
