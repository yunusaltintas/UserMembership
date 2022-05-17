using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UserMembership.Data.Entities;

namespace UserMembership.Data
{
    public class AppUser : IdentityUser<int>
    {
        public int? CompanyID { get; set; }
        public virtual Company? Company { get; set; }

    }
}
