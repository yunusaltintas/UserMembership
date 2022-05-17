using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UserMembership.Data;
using UserMembership.Data.Models;

namespace UserMembership.Controllers
{

    [Authorize(Roles = "Admin,Manager")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _roleManager.Roles.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppRole role = new AppRole()
            {
                Name = model.Name
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(p => p.Id == id);

            var model = new RoleUpdateViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var role = _roleManager.Roles.FirstOrDefault(p => p.Id == model.Id);
            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var role = _roleManager.Roles.FirstOrDefault(p => p.Id == id);

            var result = await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index", "Role");
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(int id)
        {

            var user = _userManager.Users.FirstOrDefault(p => p.Id == id);

            var roles = _roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new RoleAssignViewModel();
            model.UserId = user.Id;

            foreach (var item in roles)
            {
                var role = new RoleAssign
                {
                    RoleId = item.Id,
                    Name = item.Name,
                    IsExist = userRoles.Contains(item.Name)
                };
                model.RoleAssign.Add(role);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(RoleAssignViewModel model)
        {

            var user = _userManager.Users.FirstOrDefault(p => p.Id == model.UserId);

            foreach (var item in model.RoleAssign)
            {
                if (item.IsExist)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }

            }

            return RedirectToAction("UserList", "Role");
        }

    }
}
