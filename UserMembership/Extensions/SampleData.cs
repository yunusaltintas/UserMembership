using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMembership.Data;

namespace UserMembership.Extensions
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = (UserMembershipDbContext)serviceProvider.GetService(typeof(UserMembershipDbContext));

            var roleContext = context.Set<AppRole>();
            var userContext = context.Set<AppUser>();

            var roles = roleContext.Select(p=>p.Name).ToArray();
            var user = userContext.FirstOrDefault();

            _ = AssignRoles(serviceProvider, user.Email, roles);

            context.SaveChanges();
        }

        public static IdentityResult AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<AppUser> _userManager = (UserManager<AppUser>)services.GetService(typeof(UserManager<AppUser>));
            AppUser user = _userManager.FindByEmailAsync(email).Result;
            var result = _userManager.AddToRolesAsync(user, roles).Result;

            return result;
        }
    }
}