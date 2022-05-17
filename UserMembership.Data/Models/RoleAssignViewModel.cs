using System;
using System.Collections.Generic;
using System.Text;

namespace UserMembership.Data.Models
{
    public class RoleAssignViewModel
    {
        public int UserId { get; set; }
        public List<RoleAssign> RoleAssign { get; set; }
        public RoleAssignViewModel()
        {
            this.RoleAssign = new List<RoleAssign>();
        }
    }

    public class RoleAssign
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsExist { get; set; }

    }
}   
