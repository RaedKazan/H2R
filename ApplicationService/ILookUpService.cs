using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface ILookUpService
    {
        Task CreateLookUpCategory(AddLookUpViewModel AddLookUpViewModel);
        Task<AddLookUpViewModel> AddLookUp();
    }
}
