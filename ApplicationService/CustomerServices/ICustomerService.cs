using ApplicationService.ViewModels.Card;
using System.Threading.Tasks;

namespace ApplicationService.CustomerServices
{
    public interface ICustomerService
    {
        Task<Item> AddToCard(BuyItemViewModel Model);
    }
}
