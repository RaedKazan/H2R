using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class LookUpService : ILookUpService
    {
        private readonly IRepository<ShopItemLookUp> _electricCigaretLookUpRepository;

        public LookUpService(IRepository<ShopItemLookUp> ElectricCigaretLookUpRepository)
        {
            _electricCigaretLookUpRepository = ElectricCigaretLookUpRepository;
        }
        public async Task<AddLookUpViewModel> AddLookUp(int Type)
        {
            AddLookUpViewModel addLookUpViewModel = new AddLookUpViewModel();
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Brand == 0 && c.Category == 0 && c.Type == Type);
            addLookUpViewModel.TypeId = Type;
            return addLookUpViewModel;

        }
        public async Task<bool> CreateLookUpForItems(AddLookUpViewModel AddLookUpViewModel)
        {
            if (AddLookUpViewModel.Brand != false)
                await CreateLookUpBrand(AddLookUpViewModel);
            else
                await CreateLookUpCategory(AddLookUpViewModel);
            return true;
        }
        public async Task CreateLookUpBrand(AddLookUpViewModel AddLookUpViewModel)
        {

            // should be mapped to model first then insert to database
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Type == AddLookUpViewModel.TypeId && c.Brand != 0);
            var Id = (result.Any()) ? result.Max(c => c.Brand) : 0;
            await _electricCigaretLookUpRepository.AddAsync(new ShopItemLookUp
            {
                Brand = Id + 1,
                Category = 0,
                Type = AddLookUpViewModel.TypeId,
                Description = AddLookUpViewModel.Description
            });

        }
        public async Task CreateLookUpCategory(AddLookUpViewModel AddLookUpViewModel)
        {
            // should be mapped to model first then insert to database
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Type == AddLookUpViewModel.TypeId && c.Category != 0);
            var Id = (result.Any()) ? result.Max(c => c.Category) : 0;
            await _electricCigaretLookUpRepository.AddAsync(new ShopItemLookUp
            {
                Category = Id + 1,
                Brand = 0,
                Type = AddLookUpViewModel.TypeId,
                Description = AddLookUpViewModel.Description
            });
        }
        public async Task CreateLookUpForEjuice(AddLookUpViewModel AddLookUpViewModel)
        {

            // if the user wish to add more then one  Nicotine all must be at the same categoty
            //but every record has it own  NicotinePercentage which it's Eum
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Type == AddLookUpViewModel.TypeId && c.Category != 0);
            var Id = (result.Any()) ? result.Max(c => c.Category) + 1 : 1;
            foreach (var item in AddLookUpViewModel.NicotinePercentage)
            {
                if (item.IsChecked)
                {
                    await _electricCigaretLookUpRepository.AddAsync(new ShopItemLookUp
                    {
                        Category = Id,
                        Brand = 0,
                        Type = AddLookUpViewModel.TypeId,
                        Description = AddLookUpViewModel.Description,
                        NicotinePercentage = item.Id
                    });
                }
            }
        }
        public async Task<AddLookUpViewModel> AddLookUpForJuice()
        {
            // note the type for juice will be always 2 
            AddLookUpViewModel addLookUpViewModel = new AddLookUpViewModel();
            var result = await _electricCigaretLookUpRepository.FindAllAsync(c => c.Brand == 0 && c.Category == 0 && c.Type == 2);
            addLookUpViewModel.NicotinePercentage = ServiceHelper.CreateNicotinePercentageEumList();
            addLookUpViewModel.TypeId = 2;
            return addLookUpViewModel;
        }
    }

}
