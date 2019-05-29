using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface ILookUpService
    {
        Task<bool> CreateLookUpForItems(AddLookUpViewModel AddLookUpViewModel);
        Task<AddLookUpViewModel> AddLookUp(int Type);
        Task<AddLookUpViewModel> AddLookUpForJuice();
        Task CreateLookUpForEjuice(AddLookUpViewModel AddLookUpViewModel);
    }
}
