using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beauty2.Data;
using Beauty2.Models;

namespace Beauty2.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly Beauty2.Data.Beauty2Context _context;

        public IndexModel(Beauty2.Data.Beauty2Context context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; }

        public async Task OnGetAsync()
        {
            Artist = await _context.Artist.ToListAsync();
        }
    }
}
