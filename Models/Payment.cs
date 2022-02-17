using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty2.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string PaymentMethod { get; set; }
        public ICollection<ServicePayment> ServicePayments { get; set; }
    }
}
