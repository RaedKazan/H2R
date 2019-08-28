using ApplicationService.ViewModels.Card;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Orders
{
    public interface IOrderService
    {
        Task AddOrder(List<Item> OrderList);
    }
}
