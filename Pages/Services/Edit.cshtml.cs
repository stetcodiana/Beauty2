
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beauty2.Data;
using Beauty2.Models;

namespace Beauty2.Pages.Services
{
    public class EditModel : ServicePaymentsPageModel
    {
        private readonly Beauty2.Data.Beauty2Context _context;

        public EditModel(Beauty2.Data.Beauty2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service = await _context.Service
                                 .Include(b => b.Artist)
                                 .Include(b => b.ServicePayments)
                                 .ThenInclude(b => b.Payment)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(m => m.ID == id);

            Service = await _context.Service.FirstOrDefaultAsync(m => m.ID == id);

            if (Service == null)
            {
                return NotFound();
            }
            PopulateAssignedMethodData(_context, Service);
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "ArtistName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedPayments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceToUpdate = await _context.Service
            .Include(i => i.Artist)
            .Include(i => i.ServicePayments)
            .ThenInclude(i => i.Payment)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviceToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Service>(
            serviceToUpdate,
            "Service",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.AppointmentDate, i => i.Artist))
            {
                UpdateServicePayments(_context, selectedPayments, serviceToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateServicePayments(_context, selectedPayments, serviceToUpdate);
            PopulateAssignedMethodData(_context, serviceToUpdate);
            return Page();
        }
    }
}
           
