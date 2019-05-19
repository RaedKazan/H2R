using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService
{
    class LookUpService : ILookUpService
    {
        private readonly IRepository<ShopItemLookUp> _electricCigaretLookUpRepository;

        public LookUpService(IRepository<ShopItemLookUp> ElectricCigaretLookUpRepository)
        {
            _electricCigaretLookUpRepository = ElectricCigaretLookUpRepository;

        }
        public async Task<AddLookUpViewModel> AddLookUp()
        {
            AddLookUpViewModel addLookUpViewModel = new AddLookUpViewModel();
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Brand == 0 && c.Category == 0);
            addLookUpViewModel.TypeSelectList = result.Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();
            return addLookUpViewModel;
        }

        public  async Task CreateLookUp(AddLookUpViewModel AddLookUpViewModel)
        {
            if (AddLookUpViewModel.Brand != null)
             await   CreateLookUpBrand(AddLookUpViewModel);
            else
              await  CreateLookUpCategory(AddLookUpViewModel);


            throw new System.NotImplementedException();
        }

        public async  Task CreateLookUpBrand(AddLookUpViewModel AddLookUpViewModel)
        {

            // should be mapped to model first then insert to database
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Type == AddLookUpViewModel.TypeId && c.Brand != 0);
            var Id = result.Max(c => c.Brand);
           await  _electricCigaretLookUpRepository.AddAsync(new ShopItemLookUp
           {
               Brand =Id+1,
               Category=0,
               Type= AddLookUpViewModel.TypeId,
               Description= AddLookUpViewModel.Description
           });

        }
        public async  Task CreateLookUpCategory(AddLookUpViewModel AddLookUpViewModel)
        {
            // should be mapped to model first then insert to database
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Type == AddLookUpViewModel.TypeId && c.Category != 0);
            var Id = result.Max(c => c.Category);
            await _electricCigaretLookUpRepository.AddAsync(new ShopItemLookUp
            {
                Category = Id + 1,
                 Brand= 0,
                Type = AddLookUpViewModel.TypeId,
                Description = AddLookUpViewModel.Description
            });
        }
    }
}
