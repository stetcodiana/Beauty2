using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty2.Models
{
    public class Service
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Service Type")]
        public string Name { get; set; }
        
        public string Description { get; set; }
       
        public int Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        public int ArtistID { get; set; }
        
         public Artist Artist { get; set; }
        public ICollection<ServicePayment> ServicePayments { get; set; }
    }
}
