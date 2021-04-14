using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASpecialDay.Models
{
    public class Gift
    {
        public Gift()
        {
            IsBought = false;
        }

        [ForeignKey("GiftList")]
        public string InviteCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }        
        public int Position { get; set; }
        public bool IsBought { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
