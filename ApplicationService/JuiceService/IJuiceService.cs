using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface IJuiceService
    {
        Task<AddJuiceViewModel> AddNewJuice();
        Task<bool> CreateNewJuice(AddJuiceViewModel ElectricCigaretViewModel);
        Task<AddJuiceViewModel> AddNewJuiceWithCategoryId(int CategoryId);
        Task<GetAllJuicesViewModel> GetAllItem(int Type = 2, int Brand = 0, int Category = 0);
        Task<GetJuiceViewModel> GetItemById(int Id);
        Task UpdateItemById(int Id, AddJuiceViewModel ElectricCigaret);

        Task DeleteJuice(int Id);


    }
}
