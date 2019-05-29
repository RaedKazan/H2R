using ApplicationDataAccess.ApplicationRepository;
using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class JuiceService : IJuiceService
    {

        private readonly IRepository<JuiceItem> JuiceRepository;
        private readonly IRepository<ShopItemLookUp> ShopItemLookUp;
        private readonly IRepository<ShopItemMangment> ItemMangment;
        public JuiceService(
            IRepository<JuiceItem> JuiceRepository,
            IRepository<ShopItemLookUp> ShopItemLookUp,
            IRepository<ShopItemMangment> ItemMangment
           )
        {
            this.JuiceRepository = JuiceRepository;
            this.ShopItemLookUp = ShopItemLookUp;
            this.ItemMangment = ItemMangment;
        }

        public async Task<bool> CreateNewJuice(AddJuiceViewModel JuiceViewModel)
        {

            var Category = ShopItemLookUp.Find(c => c.Type == JuiceViewModel.TypeId && c.Id == JuiceViewModel.CategoryId).Id;

            var CategoryID = ShopItemLookUp.Find(c => c.Type == JuiceViewModel.TypeId && c.Id == JuiceViewModel.CategoryId).Category;

            var isExist = await ItemMangment.FindAllAsync(c => c.Type == JuiceViewModel.TypeId && c.Category == Category);
            if (isExist.Any())
            {
                return false;
            }
            else
            {
                var JuiceItem = new JuiceItem()
                {
                    Description = JuiceViewModel.Description,
                    Image = Encoding.ASCII.GetBytes(JuiceViewModel.Image.Substring(JuiceViewModel.Image.IndexOf("64") + 4)),
                    Name = JuiceViewModel.Name,
                    SellingPrice = JuiceViewModel.SelligPrice,
                    BuyingPrice = JuiceViewModel.BuyingPrice,
                    TypeId = JuiceViewModel.TypeId,
                    CreatedDate = DateTime.Now,
                    LastModificationDate = DateTime.Now,
                    BrandId = JuiceViewModel.BrandId.Value,
                    CategoryId = JuiceViewModel.CategoryId.Value,
                    IsActive = true
                };
                var Juice = await JuiceRepository.AddAsync(JuiceItem);

                foreach (var item in JuiceViewModel.NicotinePercentage)
                {
                    if (item.IsChecked)
                    {
                        var model = await ItemMangment.AddAsync(new ShopItemMangment
                        {
                            IsAvilable = true,
                            TotalyAvilable = item.CountToInsert,
                            TotalyInserted = item.CountToInsert,
                            TotalySold = 0,
                            Type = JuiceViewModel.TypeId,
                            Brand = JuiceViewModel.BrandId.Value,
                            Category = ShopItemLookUp.Find(c => c.Type == 2 && c.Category == CategoryID && c.NicotinePercentage == item.Id).Id,
                            JuiceId = Juice.Id

                        });
                    }
                }
                return true;
            }
        

        }
        public async Task<AddJuiceViewModel> AddNewJuice()
        {

            AddJuiceViewModel JuiceViewModel = new AddJuiceViewModel();
            JuiceViewModel.TypeId = 2;
            var ItemLookUp = await ShopItemLookUp.FindAllAsync(c => c.Type == 2);

            JuiceViewModel.BrandSelectList = ItemLookUp.Where(c => c.Type == 2 && c.Brand != 0).OrderBy(c => c.Category).Distinct().Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();

            // select Distinct for the juce duplicate ID
            JuiceViewModel.CategorySelectList = ItemLookUp.Where(c => c.Type == 2 && c.Category != 0).GroupBy(c => c.Category).Select(x => x.First()).Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();

            if (JuiceViewModel.CategorySelectList.Any())
            {
                var JuiceCategoryValue = ItemLookUp.Where(c => c.Id.ToString() == JuiceViewModel.CategorySelectList.FirstOrDefault().Value);
                JuiceViewModel.NicotinePercentage = ServiceHelper.CreateNicotinePercentageEumList(ItemLookUp.Where(c => c.Category == JuiceCategoryValue.FirstOrDefault().Category).Select(v => v.NicotinePercentage));
            }

            return JuiceViewModel;
        }
        public async Task<AddJuiceViewModel> AddNewJuiceWithCategoryId(int CategoryId)
        {
            AddJuiceViewModel JuiceViewModel = new AddJuiceViewModel();
            JuiceViewModel.TypeId = 2;
            var ItemLookUp = await ShopItemLookUp.FindAllAsync(c => c.Type == 2);

            JuiceViewModel.BrandSelectList = ItemLookUp.Where(c => c.Type == 2 && c.Brand != 0).OrderBy(c => c.Category).Distinct().Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
            }).ToList();

            // select Distinct for the juce duplicate ID
            JuiceViewModel.CategorySelectList = ItemLookUp.Where(c => c.Type == 2 && c.Category != 0).GroupBy(c => c.Category).Select(x => x.First()).Select(x => new SelectListItem()
            {
                Text = x.Description,
                Value = x.Id.ToString(),
                Selected = x.Id == CategoryId ? true : false
            }).ToList();

            if (JuiceViewModel.CategorySelectList.Any())
            {

                var JuiceCategoryValue = ItemLookUp.Where(c => c.Id == CategoryId);
                JuiceViewModel.NicotinePercentage = ServiceHelper.CreateNicotinePercentageEumList(ItemLookUp.Where(c => c.Category == JuiceCategoryValue.FirstOrDefault().Category).Select(v => v.NicotinePercentage));
            }

            return JuiceViewModel;
        }
        public async Task<GetAllJuicesViewModel> GetAllItem(int Type = 2, int Brand = 0, int Category = 0)
        {
            var electricCigarets = await JuiceRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.TypeId == Type).ToListAsync();
            if (Brand != 0)
                electricCigarets.Where(c => c.BrandId == Brand).ToList();
            if (Category != 0)
                electricCigarets.Where(c => c.CategoryId == Category).ToList();

            return new GetAllJuicesViewModel(electricCigarets);
        }
        public async Task<GetJuiceViewModel> GetItemById(int Id)
        {
            var juiceItem = await JuiceRepository.GetAllIncluding(c => c.Category, x => x.Brand, a => a.ElectricCigaretMangment).Where(z => z.Id == Id).FirstAsync();
            return new GetJuiceViewModel(juiceItem);
        }
        public async Task UpdateItemById(int Id, AddJuiceViewModel JuiceViewModel)
        {
          //  var Item = await JuiceRepository.GetAllIncluding(c => c.ElectricCigaretMangment).Where(c => c.Id == Id).FirstAsync();
          //  Item.Image = Encoding.ASCII.GetBytes(JuiceViewModel.Image.Substring(JuiceViewModel.Image.IndexOf("64") + 4));
          //  Item.Name = JuiceViewModel.Name;
          //  Item.LastModificationDate = DateTime.Now;
          //  Item.Description = JuiceViewModel.Description;
          //  Item.BuyingPrice = JuiceViewModel.BuyingPrice;
          //  Item.SellingPrice = JuiceViewModel.SelligPrice;
          // await  JuiceRepository.UpdateAsync(Item,Id);

          //  foreach (var item in Item.ElectricCigaretMangment)
          //  {

          //  }

          //  foreach (var item in JuiceViewModel.NicotinePercentage)
          //  {
          //      if (item.IsChecked)
          //      {
          //          var model = await ItemMangment.AddAsync(new ShopItemMangment
          //          {
          //              IsAvilable = true,
          //              TotalyAvilable = item.CountToInsert,
          //              TotalyInserted = item.CountToInsert,
          //              TotalySold = 0,
          //              Type = JuiceViewModel.TypeId,
          //              Brand = JuiceViewModel.BrandId.Value,
          //              Category = ShopItemLookUp.Find(c => c.Type == 2 && c.Category == Category && c.NicotinePercentage == item.Id).Id,
          //              JuiceId = Item.Id

          //          });
          //      }
          //  }
          //  var electricCigaretMangment = ItemMangment.Find(c => c.Id == Item.ElectricCigaretMangmentId);
          //  electricCigaretMangment.TotalyAvilable = electricCigaretMangment.TotalyAvilable + ElectricCigaret.;
          //  electricCigaretMangment.TotalyInserted = electricCigaretMangment.TotalyInserted + ElectricCigaret.CountToInsert;
          //await  ItemMangment.UpdateAsync(electricCigaretMangment, electricCigaretMangment.Id);
        }
        public async Task DeleteJuice(int Id)
        {
            var Juice = await JuiceRepository.GetAsync(Id);
            Juice.IsActive = false;
            await JuiceRepository.UpdateAsync(Juice, Id);
        }
    }
}
