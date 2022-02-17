using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beauty2.Data;
using Beauty2.Models;

namespace Beauty2.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly Beauty2.Data.Beauty2Context _context;

        public IndexModel(Beauty2.Data.Beauty2Context context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; }
        public ServiceData ServiceD { get; set; }
        public int ServiceID { get; set; }
        public int PaymentID { get; set; }
        public async Task OnGetAsync(int? id, int? paymentID)
        {
            ServiceD = new ServiceData();
            ServiceD.Services = await _context.Service
            .Include(b => b.Artist)
            .Include(b => b.ServicePayments)
            .ThenInclude(b => b.Payment)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                ServiceID = id.Value;
                Service service = ServiceD.Services
                .Where(i => i.ID == id.Value).Single();
                ServiceD.Payments = service.ServicePayments.Select(s => s.Payment);
            }
        }

        public async Task OnGetAsync()
        {
            Service = await _context.Service.Include(b => b.Artist).ToListAsync();

        }
    }
}
