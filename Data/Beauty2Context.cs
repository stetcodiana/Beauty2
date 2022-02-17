using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beauty2.Models;

namespace Beauty2.Data
{
    public class Beauty2Context : DbContext
    {
        public Beauty2Context (DbContextOptions<Beauty2Context> options)
            : base(options)
        {
        }

        public DbSet<Beauty2.Models.Service> Service { get; set; }

        public DbSet<Beauty2.Models.Artist> Artist { get; set; }

        public DbSet<Beauty2.Models.Payment> Payment { get; set; }
    }
}
