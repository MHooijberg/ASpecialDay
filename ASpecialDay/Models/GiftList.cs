using ASpecialDay.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASpecialDay.Models
{
    public class GiftList
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InviteCode { get; set; }

        public virtual Bride Bride { get; set; }
        public virtual ICollection<Gift> Gifts { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<BoughtBy> Boughts { get; set; }
    }
}
