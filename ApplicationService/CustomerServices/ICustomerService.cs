using ApplicationService.ViewModels.Card;
using ApplicationService.ViewModels.Customer;
using System.Threading.Tasks;

namespace ApplicationService.CustomerServices
{
    public interface ICustomerService
    {
        Task<Item> AddToCard(BuyItemViewModel Model);
        Task<ViewAllItemsForCustomers> GetAllItems();
    }
}
