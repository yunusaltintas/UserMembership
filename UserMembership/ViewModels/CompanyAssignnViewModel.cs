using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMembership.ViewModels
{
    public class CompanyAssignnViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string SelectedCompanyId { get; set; }
        public List<SelectListItem> Companies { get; set; }
    }
}
