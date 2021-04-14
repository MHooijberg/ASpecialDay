using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASpecialDay.Pages
{
    public class GiftListModel : PageModel
    {
        [BindProperty]
        public int InviteCode { get; set; }
        public void OnGet(int inviteCode)
        {
            InviteCode = inviteCode;
        }
    }
}
