using System.Threading.Tasks;

namespace ApplicationService
{
    public interface IItemMangmentService
    {
        Task GetAllItemsInventory(int? Type=0, int? Brand=0, int? Category=0);
    }
}
