using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty2.Models
{
    public class ServiceData
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<ServicePayment> ServicePayments { get; set; }
    }
}
