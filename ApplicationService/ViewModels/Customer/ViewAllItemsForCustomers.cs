using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.ViewModels.Customer
{
    public class ViewAllItemsForCustomers
    {
        public GetAllElectricCigaretViewModel GetAllElectricCigaretViewModel { set; get; }
        public GetAllJuicesViewModel GetAllJuicesViewModel { set; get; }

        //public ViewAllItemsForCustomers(GetAllElectricCigaretViewModel GetAllElectricCigaretViewModel, GetAllJuicesViewModel GetAllJuicesViewModel)
        //{
        //    this.GetAllElectricCigaretViewModel = GetAllElectricCigaretViewModel;
        //    this.GetAllJuicesViewModel = GetAllJuicesViewModel;
        //}

        public ViewAllItemsForCustomers(GetAllElectricCigaretViewModel GetAllElectricCigaretViewModel)
        {
            this.GetAllElectricCigaretViewModel = GetAllElectricCigaretViewModel;
            //   this.GetAllJuicesViewModel = GetAllJuicesViewModel;
        }
        public ViewAllItemsForCustomers()
        {
            
        }

    }
}
