using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ris2022.Data;
using Ris2022.Data.Configuration;
using Ris2022.Resources;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Ris2022.Data.Models;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Ris2022.Data.Configuration.Entities;

namespace Ris2022.Controllers
{
    public class RolesController : Controller
    {
        public readonly RisDBContext _context;
        public readonly UserManager<RisAppUser> _userManger;
        private readonly IToastNotification _toastNotification;


        public RolesController(RisDBContext context, UserManager<RisAppUser> userManager,IToastNotification toastNotification)
        {
            _context = context;
            _userManger = userManager;
            _toastNotification = toastNotification;
        }
        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var risDBContext = _context.Roles
                .Include(r => r.Name)
                .Include(r => r.NormalizedName);

            return View(await risDBContext.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Roles = await _context.Roles
                .Include(r => r.Name)
                .Include(r => r.NormalizedName)
                .Take(1).ToListAsync();

            var role = Roles.FirstOrDefault();
            if (Roles== null)
            {
                return NotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            RoleConfiguration role = new()
            {

            };
            return View(role);
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
