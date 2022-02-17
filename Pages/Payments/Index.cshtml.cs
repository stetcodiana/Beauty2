using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beauty2.Data;
using Beauty2.Models;

namespace Beauty2.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly Beauty2.Data.Beauty2Context _context;

        public IndexModel(Beauty2.Data.Beauty2Context context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; }

        public async Task OnGetAsync()
        {
            Payment = await _context.Payment.ToListAsync();
        }
    }
}
