using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASpecialDay.Areas.Identity.Data;
using ASpecialDay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASpecialDay.Pages
{
    public class GiftListModel : PageModel
    {
        private readonly ASpecialDayContext _context;
        private readonly SignInManager<Bride> _signInManager;
        private readonly UserManager<Bride> _userManager;

        [BindProperty] public GiftList _GiftList { get; set; }
        [BindProperty] public Gift NewGift { get; set; } = new Gift();
        [BindProperty] public string InviteCode { get; set; }

        public GiftListModel(ASpecialDayContext context, SignInManager<Bride> signInManager, UserManager<Bride> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string inviteCode)
        {
            InviteCode = inviteCode;
            GiftList giftList = _context.GiftLists.Where(_giftList => _giftList.InviteCode == inviteCode).First();

            Bride loggedInUser = await _userManager.GetUserAsync(User);
            if (giftList != null && (!_signInManager.IsSignedIn(User) || (_signInManager.IsSignedIn(User) && giftList.Bride == loggedInUser)))
            {
                _GiftList = giftList;
                if (_GiftList.Gifts != null)
                {
                    _GiftList.Gifts = (ICollection<Gift>)_GiftList.Gifts.OrderBy(_gift => _gift.Position);
                }
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPostAddGift(string inviteCode)
        {
            if (ModelState.IsValid)
            {
                int calculatedPosition;
                if (NewGift.Position == null) {
                    calculatedPosition = _GiftList.Gifts == null || _GiftList.Gifts.Count == 0 ?
                        calculatedPosition = 0 :
                        (int) _GiftList.Gifts.Max(gift => gift.Position) + 1;
                }
                else
                {
                    calculatedPosition = (int) NewGift.Position;
                }

                Gift gift = new Gift() {
                    Description = NewGift.Description,
                    InviteCode = inviteCode,
                    IsBought = NewGift.IsBought == null ? NewGift.IsBought : false,
                    Name = NewGift.Name,
                    Position = calculatedPosition
                };
                _context.Gifts.Add(gift);
                _context.SaveChanges();
            }
            return Page();
        }

        public IActionResult OnPostDelete(Gift gift)
        {
            if (ModelState.IsValid)
            {
                if (gift.IsBought == true)
                {
                    _context.Boughts.RemoveRange(
                        _GiftList.Boughts.Where(_bought => _bought.Gift == gift)
                    );
                }
                _context.Gifts.Remove(gift);
                _context.SaveChanges();
            }
            return Page();
        }

        public IActionResult OnPostMoveDown(Gift gift)
        {
            if (ModelState.IsValid)
            {
                List<Gift> gifts = _GiftList.Gifts.ToList();
                Gift switchedGift = gifts[gifts.IndexOf(gift) + 1];
                _context.Gifts.FirstOrDefault(_gift => _gift == gift).Position++;
                _context.Gifts.FirstOrDefault(_gift => _gift == switchedGift).Position--;
                _context.SaveChanges();
            }
            return Page();
        }

        public IActionResult OnPostMoveUp(Gift gift)
        {
            if (ModelState.IsValid)
            {
                List<Gift> gifts = _GiftList.Gifts.ToList();
                Gift switchedGift = gifts[gifts.IndexOf(gift) - 1];
                _context.Gifts.FirstOrDefault(_gift => _gift == gift).Position--;
                _context.Gifts.FirstOrDefault(_gift => _gift == switchedGift).Position++;
                _context.SaveChanges();
            }
            return Page();
        }



    }
}
