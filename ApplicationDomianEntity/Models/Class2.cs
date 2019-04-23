using System.ComponentModel.DataAnnotations;
namespace ApplicationDomianEntity.Models
{
    public class Class2
    {
        [Key]
        public int Id { get; set; }
        public int EnglishName { get; set; }

        public int ArabicName { get; set; }
        public int class1 { get; set; }

        public virtual Class1 MyProperty { get; set; }
    }
}
