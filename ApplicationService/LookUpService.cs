using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
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
        public async Task AddLookUp()
        {

            AddLookUpViewModel addLookUpViewModel = new AddLookUpViewModel();
            var result = await _electricCigaretLookUpRepository.GetAllAsync();

            //return result.Where(c => c.Brand == 0 && c.Category == 0);

                }

        public Task CreateLookUp ()
        {
            throw new System.NotImplementedException();
        }
    }
}
