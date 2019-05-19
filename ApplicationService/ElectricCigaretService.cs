using ApplicationDataAccess.ApplicationRepository;
using ApplicationDataAccess.ApplicationUOF;
using ApplicationDomianEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationService.ViewModels;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService
{
    public class ElectricCigaretService : IElectricCigaretService
    {
        private readonly IRepository<ShopItemLookUp> ElectricCigaretLookUpRepository;
        private readonly IRepository<ShopItem> ElectricCigaretRepository;
        private readonly IRepository<ShopItemMangment> ElectricCigaretMangment;


        IUnitOfWork _unitOfWork;

        public ElectricCigaretService(
            IRepository<ShopItem> ElectricCigaretRepository,
            IRepository<ShopItemLookUp> ElectricCigaretLookUpRepository,
            IRepository<ShopItemMangment> ElectricCigaretMangment,
            IUnitOfWork unitOfWork)
        {
            this.ElectricCigaretLookUpRepository = ElectricCigaretLookUpRepository;
            this.ElectricCigaretRepository = ElectricCigaretRepository;
            this.ElectricCigaretMangment = ElectricCigaretMangment;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddElectricCigaret(AddElectricCigaretViewModel ElectricCigaretViewModel)
        {
            var ElectricCigaret = new ShopItem()
            {
                Description = ElectricCigaretViewModel.Description,
                Image = Encoding.ASCII.GetBytes(ElectricCigaretViewModel.Image.Substring(ElectricCigaretViewModel.Image.IndexOf("64") + 4)),
                Name = ElectricCigaretViewModel.Name,
                Price = ElectricCigaretViewModel.Price,
                TypeId = ElectricCigaretViewModel.Type.Value,
                CreatedDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
                BrandId = ElectricCigaretViewModel.Brand.Value
            };

            if (!ElectricCigaretMangment.GetAll().Where(c => c.Type == ElectricCigaretViewModel.Type && c.Brand == ElectricCigaretViewModel.Brand).Any())
            {
                var model = await ElectricCigaretMangment.AddAsync(new ShopItemMangment
                {
                    IsAvilable = true,
                    TotalyAvilable = ElectricCigaretViewModel.CountToInsert,
                    TotalyInserted = ElectricCigaretViewModel.CountToInsert,
                    TotalySold = 0,
                    Type = ElectricCigaretViewModel.Type.Value,
                    Brand = ElectricCigaretViewModel.Brand.Value
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
            await ElectricCigaretMangment.DeleteAsync(new ShopItemMangment { Id=ElectricCigaret.ElectricCigaretMangment.Id});
            await ElectricCigaretRepository.DeleteAsync(ElectricCigaret);
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

        public async Task<AddElectricCigaretViewModel> GetElectricCigaretLookUps()
        {
            AddElectricCigaretViewModel ElectricCigaretViewModel = new AddElectricCigaretViewModel();
            var ElectricCigaretLookUp = await ElectricCigaretLookUpRepository.GetAllAsync();
            ElectricCigaretViewModel.BrandSelectList = ElectricCigaretLookUp.Where(c=>c.Type==1 && c.Brand !=0).Select(x=>  new SelectListItem()
            { Text=x.Description,
             Value= x.Id.ToString(),
            }).ToList();

            ElectricCigaretViewModel.TypeSelectList = ElectricCigaretLookUp.Where(c => c.Type == 1 && c.Category!=0).Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();


            return ElectricCigaretViewModel;
        }
        public Task UpdateElectricCigaret(int Id, ShopItem ElectricCigaret)
        {
            throw new System.NotImplementedException();
        }
    }
}
