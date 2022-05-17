using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMembership.Data;
using UserMembership.Data.Entities;
using UserMembership.Data.Models;
using UserMembership.Service;
using UserMembership.ViewModels;

namespace UserMembership.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class CompanyInvitationController : Controller
    {
        private readonly IBaseService<Company> _service;
        private readonly UserManager<AppUser> _userManager;

        public CompanyInvitationController(Service.IBaseService<Company> service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _service.GetAllAsync().Result;
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Company company = new Company()
            {
                Name = model.Name
            };

            var result = await _service.AddAsync(company);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var company = await _service.GetByIdAsync(id);

            var model = new CompanyUpdateViewModel()
            {
                Id = company.Id,
                Name = company.Name
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

            var company = await _service.GetByIdAsync(model.Id);
            company.Name = model.Name;

            var result = _service.Update(company);

            return RedirectToAction("Index", "CompanyInvitation");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _service.GetByIdAsync(id);
            _service.Remove(company);

            return RedirectToAction("Index", "CompanyInvitation");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignCompany(int id)
        {
            var user = _userManager.Users.FirstOrDefault(p => p.Id == id);
            var companies = await _service.GetAllAsync();
            var model = new CompanyAssignnViewModel();

            model.UserId = user.Id;
            model.UserName = user.UserName;

            var items = companies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            model.Companies = items;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignCompany(CompanyAssignnViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(p => p.Id == model.UserId);

            if (model.SelectedCompanyId != "Please select one")
            {
                user.CompanyID = Convert.ToInt32(model.SelectedCompanyId);
            }
            else
            {
                user.CompanyID = null;
            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction("UserList", "Role");
        }
    }
}
