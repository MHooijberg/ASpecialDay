using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASpecialDay.Models
{
    public class BoughtBy
    {
        [Key]
        public int BoughtByID { get; set; }

        public virtual Gift Gift { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
