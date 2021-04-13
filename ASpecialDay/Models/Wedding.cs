using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASpecialDay.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID { get; set; }
        [Required]
        public string Location { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
