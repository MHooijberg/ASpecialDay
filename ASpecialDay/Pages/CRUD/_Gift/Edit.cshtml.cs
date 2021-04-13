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

namespace ASpecialDay.Pages.CRUD._Gift
{
    public class EditModel : PageModel
    {
        private readonly ASpecialDay.Areas.Identity.Data.ASpecialDayContext _context;

        public EditModel(ASpecialDay.Areas.Identity.Data.ASpecialDayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gift Gift { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gift = await _context.Gifts.FirstOrDefaultAsync(m => m.InviteCode == id);

            if (Gift == null)
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

            _context.Attach(Gift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftExists(Gift.InviteCode))
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

        private bool GiftExists(int id)
        {
            return _context.Gifts.Any(e => e.InviteCode == id);
        }
    }
}
