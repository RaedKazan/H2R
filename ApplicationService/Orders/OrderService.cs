using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels.Card;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> OrderRepository;
        public OrderService(IRepository<Order> OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }

        public async Task AddOrder(List<Item> OrderList)
        {
            var maxOrderId = OrderRepository.Count()+1;
            foreach (var item in OrderList)
            {
              await   OrderRepository.AddAsync(new Order
                {
                    ApplicationUserId = item.Product.UserId,
                    ItemMangmentId = item.Product.JuiceMangmentId,
                    JuiceItemId = item.Product.JuiceId,
                    OrderId = maxOrderId,
                    Quantity = item.Quantity,
                    IsCanceled = false,
                    IsPending = true,
                    ShopItemId = item.Product.ItemId
                });
            }
            




        }
    }
}
