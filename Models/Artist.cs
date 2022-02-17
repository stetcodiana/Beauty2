using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty2.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
