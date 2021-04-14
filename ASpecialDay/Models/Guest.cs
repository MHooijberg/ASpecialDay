using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASpecialDay.Models
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }
        [ForeignKey("GiftList")]
        public string InviteCode { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public virtual ICollection<Gift> Gifts { get; set; }

    }
}
