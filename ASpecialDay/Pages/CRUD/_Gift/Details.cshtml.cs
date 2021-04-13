using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASpecialDay.Areas.Identity.Data;
using ASpecialDay.Models;

namespace ASpecialDay.Pages.CRUD._Gift
{
    public class DetailsModel : PageModel
    {
        private readonly ASpecialDay.Areas.Identity.Data.ASpecialDayContext _context;

        public DetailsModel(ASpecialDay.Areas.Identity.Data.ASpecialDayContext context)
        {
            _context = context;
        }

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
    }
}
