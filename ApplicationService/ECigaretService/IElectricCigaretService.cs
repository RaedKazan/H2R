using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface IElectricCigaretService
    {
        Task<bool> AddElectricCigaret(AddElectricCigaretViewModel ElectricCigaretViewModel);
        Task<GetAllElectricCigaretViewModel> GetAllItem(int Type=0 , int Brand =0, int Category=0);
        Task<GetElectricCigaretViewModel> GetItemById(int Id);
        Task<AddElectricCigaretViewModel> GetElectricCigaretLookUps(int TypeId);
        Task UpdateItemById(int Id, AddElectricCigaretViewModel ElectricCigaret);
        Task DeleteElectricCigaret(int Id);
    }
}
