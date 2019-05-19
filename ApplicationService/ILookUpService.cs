using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface ILookUpService
    {
        Task<AddLookUpViewModel> AddLookUp();
        Task CreateLookUp(AddLookUpViewModel AddLookUpViewModel);
    }
}
