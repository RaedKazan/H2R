using System.ComponentModel.DataAnnotations;

namespace ApplicationDomianEntity.Models
{
    public enum SystemEum
    {
       ZeroPercent = 1,
       ThreePercent = 2,
       SixPercent = 3,
       NinePercent = 4,
       TwelvePercent = 5,
       FifteenePercent = 6,
    }
    public enum DomainValues
    {
        Vape = 1,
        Juice = 2,
        ECigaret = 3
    }
    public enum ErrorEnum
    {
        [Display(Name = "TheQuantityIsNotEnough")]
        TheQuantityIsNotEnough = 1,
        Juice = 2,
        ECigaret = 3
    }
}
