using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface IElectricCigaretService
    {
        Task AddElectricCigaret(AddElectricCigaretViewModel ElectricCigaretViewModel);
        Task<GetAllElectricCigaretViewModel> GetAllElectricCigaret();
        Task<GetElectricCigaretViewModel> GetElectricCigaretById(int Id);
        Task<AddElectricCigaretViewModel> GetElectricCigaretLookUps();
        Task UpdateElectricCigaret(int Id, ShopItem ElectricCigaret);

    }
}
