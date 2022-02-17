using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty2.Models
{
    public class ServicePayment
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
    }
}
