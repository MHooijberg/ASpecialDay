using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASpecialDay.Areas.Identity.Data;
using ASpecialDay.Models;

namespace ASpecialDay.Pages.CRUD._Guest
{
    public class EditModel : PageModel
    {
        private readonly ASpecialDay.Areas.Identity.Data.ASpecialDayContext _context;

        public EditModel(ASpecialDay.Areas.Identity.Data.ASpecialDayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest Guest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guest = await _context.Guests.FirstOrDefaultAsync(m => m.GuestID == id);

            if (Guest == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Guest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(Guest.GuestID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.GuestID == id);
        }
    }
}
