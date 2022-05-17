using System;
using System.Collections.Generic;
using System.Text;

namespace UserMembership.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
