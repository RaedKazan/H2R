using System.ComponentModel.DataAnnotations;
namespace ApplicationDomianEntity.Models
{
    public class Class3
    {
        [Key]
        public int Id { get; set; }
        public int FirstName { get; set; }

        public int LastName { get; set; }
    }
}
