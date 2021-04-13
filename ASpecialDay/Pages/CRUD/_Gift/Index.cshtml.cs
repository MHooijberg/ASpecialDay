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
    public class IndexModel : PageModel
    {
        private readonly ASpecialDay.Areas.Identity.Data.ASpecialDayContext _context;

        public IndexModel(ASpecialDay.Areas.Identity.Data.ASpecialDayContext context)
        {
            _context = context;
        }

        public IList<Gift> Gift { get;set; }

        public async Task OnGetAsync()
        {
            Gift = await _context.Gifts.ToListAsync();
        }
    }
}
