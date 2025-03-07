﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASpecialDay.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Bride class
    public class Bride : IdentityUser
    {
        [ForeignKey("Wedding")]
        public int WeddingID { get; set; }
    }
}
