using System.ComponentModel.DataAnnotations;

namespace Tut12.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}