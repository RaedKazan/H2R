using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomianEntity.Models
{
    public class Class1
    {
        [Key]
        public int Id { get; set; }
        public int FirstName { get; set; }

        public int LastName { get; set; }
        public virtual ICollection<Class2> MyProperty { get; set; }
    }
}
