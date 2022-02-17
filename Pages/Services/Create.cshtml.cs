using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beauty2.Data;
using Beauty2.Models;

namespace Beauty2.Pages.Services
{
    public class CreateModel : ServicePaymentsPageModel
    {
        private readonly Beauty2.Data.Beauty2Context _context;

        public CreateModel(Beauty2.Data.Beauty2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "ArtistName");
            var service = new Service();
            service.ServicePayments = new List<ServicePayment>();
            PopulateAssignedMethodData(_context, service);
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedPayments)
        {
            var newService = new Service();
            if (selectedPayments != null)
            {
                newService.ServicePayments = new List<ServicePayment>();
                foreach (var cat in selectedPayments)
                {
                    var catToAdd = new ServicePayment
                    {
                        PaymentID = int.Parse(cat)
                    };
                    newService.ServicePayments.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Service>(
            newService,
            "Service",
            i => i.Name, i => i.Description,
            i => i.Price, i => i.AppointmentDate, i => i.ArtistID))
            {
                _context.Service.Add(newService);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedMethodData(_context, newService);
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
