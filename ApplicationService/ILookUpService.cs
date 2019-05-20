using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface ILookUpService
    {
        Task<bool> CreateLookUp(AddLookUpViewModel AddLookUpViewModel);
        Task<AddLookUpViewModel> AddLookUp(int Type);
    }
}
