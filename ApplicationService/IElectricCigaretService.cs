using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface IElectricCigaretService
    {
        Task<bool> AddElectricCigaret(AddElectricCigaretViewModel ElectricCigaretViewModel);
        Task<GetAllElectricCigaretViewModel> GetAllElectricCigaret();
        Task<GetElectricCigaretViewModel> GetElectricCigaretById(int Id);
        Task<AddElectricCigaretViewModel> GetElectricCigaretLookUps(int TypeId);
        Task UpdateElectricCigaret(int Id, AddElectricCigaretViewModel ElectricCigaret);
    }
}
