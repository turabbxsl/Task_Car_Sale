using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Max 100 Herf ")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Min 2 Herf")]
        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; } = Convert.ToDateTime(DateTime.Now.ToShortDateString());

    }
}
