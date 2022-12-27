using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ris2022.Data;
using Ris2022.Data.Models;
using Ris2022.Data.ViewModel;
using Ris2022.Pages.Shared;
using Ris2022.Pages.Account;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace Ris2022.Controllers
{
    [Authorize(Roles ="administrator")]
   // [Authorize(Roles ="User")]
    public class AdministrationController : Controller
    {
        private readonly RisDBContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<RisAppUser> userManager;

        public AdministrationController(RisDBContext context,
                                        RoleManager<IdentityRole> roleManager,
                                        UserManager<RisAppUser> userManager)
        {
            _roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
            
        }

        [HttpGet]
        public IActionResult ListUsers()
        {

            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole() { Name = model.RoleName };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "administration");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
           var role=await _roleManager.FindByIdAsync(id);

            if (role==null)
            {
                ViewBag.ErrorMessage = $"Role with Id={id} cannot be Found";
                return RedirectToAction("NotFound","Administration");
            }

            var model = new EditRoleViewModel
            {
                id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                    model.Users.Add(user.UserName);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id={model.id} cannot be Found";
                return RedirectToAction("NotFound", "Administration");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors )
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string RoleId)
        {
            ViewBag.roleId = RoleId;

            var role = await _roleManager.FindByIdAsync(RoleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id={RoleId} cannot be Found";
                return RedirectToAction("NotFound", "Administration");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;

                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model,string RoleId)
        {

            var role = await _roleManager.FindByIdAsync(RoleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id={RoleId} cannot be Found";
                return RedirectToAction("NotFound", "Administration");
            }

            for (int i=0; i<model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user,role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }

                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }

                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else 
                        return RedirectToAction("EditRole",new {id = RoleId });
                }
            }

            return RedirectToAction("EditRole", new { id = RoleId });
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
