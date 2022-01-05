using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Car
    {

        [Key]
        public int CarID { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="Max 100 Herf Daxil Ede Bilersiniz")]
        public string Brand { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Max 100 Herf Daxil Ede Bilersiniz")]
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SaleDate { get; set; }


    }
}
