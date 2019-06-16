using ApplicationDomianEntity.Models;
using ApplicationService.ViewModels;
using System.Collections.Generic;

namespace ApplicationService
{
    static class ServiceHelper
    {

        public static List<NicotinePercentage> CreateNicotinePercentageEumList()
        {
            var NicotinePercentage = new List<NicotinePercentage>();

            NicotinePercentage.Add(new ViewModels.NicotinePercentage
            {
                Id = (int)SystemEum.ZeroPercent,
                Name = "Zero Percent"
            });
            NicotinePercentage.Add(new ViewModels.NicotinePercentage
            {
                Id = (int)SystemEum.ThreePercent,
                Name = "Three Percent"
            });
            NicotinePercentage.Add(new ViewModels.NicotinePercentage
            {
                Id = (int)SystemEum.SixPercent,
                Name = "Six Percent"
            });
            NicotinePercentage.Add(new ViewModels.NicotinePercentage
            {
                Id = (int)SystemEum.NinePercent,
                Name = "Nine Percent"
            });
            NicotinePercentage.Add(new ViewModels.NicotinePercentage
            {
                Id = (int)SystemEum.TwelvePercent,
                Name = "Twelve Percent"
            });
            NicotinePercentage.Add(new ViewModels.NicotinePercentage
            {
                Id = (int)SystemEum.FifteenePercent,
                Name = "Fifteene Percent"
            });

            return NicotinePercentage;
        }
        public static List<NicotinePercentage> CreateNicotinePercentageEumList(IEnumerable<double> Range)
        {
            var NicotinePercentage = new List<NicotinePercentage>();
            foreach (var item in Range)
            {
                if (item == (int)SystemEum.ZeroPercent)
                    NicotinePercentage.Add(new ViewModels.NicotinePercentage
                    {
                        Id = (int)SystemEum.ZeroPercent,
                        Name = "Zero Percent",
                        IsChecked = false
                    });
                if (item == (int)SystemEum.ThreePercent)
                    NicotinePercentage.Add(new ViewModels.NicotinePercentage
                    {
                        Id = (int)SystemEum.ThreePercent,
                        Name = "Three Percent",
                        IsChecked = false


                    });
                if (item == (int)SystemEum.SixPercent)
                    NicotinePercentage.Add(new ViewModels.NicotinePercentage
                    {
                        Id = (int)SystemEum.SixPercent,
                        Name = "Six Percent",
                        IsChecked = false

                    });
                if (item == (int)SystemEum.NinePercent)
                    NicotinePercentage.Add(new ViewModels.NicotinePercentage
                    {
                        Id = (int)SystemEum.NinePercent,
                        Name = "Nine Percent",
                        IsChecked = false

                    });
                if (item == (int)SystemEum.TwelvePercent)
                    NicotinePercentage.Add(new ViewModels.NicotinePercentage
                    {
                        Id = (int)SystemEum.TwelvePercent,
                        Name = "Twelve Percent",
                        IsChecked = false

                    });
                if (item == (int)SystemEum.FifteenePercent)
                    NicotinePercentage.Add(new ViewModels.NicotinePercentage
                    {
                        Id = (int)SystemEum.FifteenePercent,
                        Name = "Fifteene Percent",
                        IsChecked = false

                    });


            }
            return NicotinePercentage;
        }


        public static string GetNicotinePercentageName(int Id)
        {


            if (Id == (int)SystemEum.ZeroPercent)
                return "Zero Percent";


            else if (Id == (int)SystemEum.ThreePercent)


                return "Three Percent";



            else if (Id == (int)SystemEum.SixPercent)


                return "Six Percent";

            else if (Id == (int)SystemEum.NinePercent)


                return "Nine Percent";

            else if (Id == (int)SystemEum.TwelvePercent)

                return "Twelve Percent";



            else if (Id == (int)SystemEum.FifteenePercent)
                return "Fifteene Percent";
            else return string.Empty;
            


            

        } 
      
    } 
}
