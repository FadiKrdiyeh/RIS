using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ris2022.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ris2022.Data;
using Ris2022.Resources;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using NToastNotify;
using System.Text;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ris2022.Controllers
{
    public class UserRolesController : Controller
    {
        public readonly RisDBContext _context;
        public readonly UserManager<RisAppUser> _userManager;
        private readonly IToastNotification _toastNotification;

        public UserRolesController(RisDBContext context, UserManager<RisAppUser> userManager, IToastNotification toastNotification)
        {
            _context = context;
            _userManager = userManager;
            _toastNotification = toastNotification;


        }
        // GET: UserRolesController
        public async Task<ActionResult> Index()
        {
            var risDBContext = _context.UserRoles
                .Include(u => u.RoleId)
                .Include(u => u.UserId);
                

            return View(await risDBContext.ToListAsync());
        }

        // GET: UserRolesController/Details/5
        public async Task<IActionResult> Details(int? uid,int? rid)
        {
            if ( rid==null || uid==null || _context.UserRoles==null)
            {
                return NotFound();
            }

            var Userroles = await _context.UserRoles
                .Include(u => u.RoleId)
                .Include(u => u.UserId)
                .Take(1).ToListAsync();
            var Userrole = Userroles.FirstOrDefault();
            if (Userroles == null)
            {
                return NotFound();

            }

            return View(Userrole);
        }

        // GET: UserRolesController/Create
        public IActionResult Create()
        {
            
            Userrole userrole = new()
            {
                
            };

            return View(userrole);
        }

        // POST: UserRolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Userrole userrole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userrole);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("تم الحفظ بنجاح");
                return RedirectToAction(nameof(Index));


            }
            var Userrole = await _context.UserRoles.FindAsync();
            ViewData["UserId"] = new SelectList(_context.UserRoles, "UserId", "UserId", Userrole.UserId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", Userrole.RoleId);

            return View(userrole);
        }

       
        

        // GET: UserRolesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id==null || _context.UserRoles==null)
            {
                return NotFound();
            }

            var Userrole = await _context.UserRoles.FindAsync(id);
            if(Userrole==null)
            {
                return NotFound();
            }

            
            ViewData["UserId"] = new SelectList(_context.UserRoles, "UserId", "UserId", Userrole.UserId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", Userrole.RoleId);

            return View(Userrole);
        }

        // POST: UserRolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,RoleId")] Userrole userrole)
        {
            if (id != userrole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(userrole);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddSuccessToastMessage("تم التعديل بنجاح");
                   

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserroleExists(userrole.Id))
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                        _toastNotification.AddErrorToastMessage("تعديل فاشل");
                    }
                    
                }
                return RedirectToAction(nameof(Index));
            }
            var Userrole = await _context.UserRoles.FindAsync();
            ViewData["UserId"] = new SelectList(_context.UserRoles, "UserId", "UserId", Userrole.UserId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", Userrole.RoleId);
            return View(userrole);
        }

        // GET: UserRolesController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var Userroles = await _context.UserRoles
                .Include(u => u.RoleId)
                .Include(u => u.UserId)
                .Take(1).ToListAsync();
            var Userrole = Userroles.FirstOrDefault();
            if (Userrole == null)
            {
                return NotFound();

            }
            ViewData["UserId"] = new SelectList(_context.UserRoles, "UserId", "UserId", Userrole.UserId);
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "RoleId", "RoleId", Userrole.RoleId);

            return View(Userroles);
        }

        // POST: UserRolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set 'RisDBContext.Userroles'  is null.");
            }
            var Userrole = await _context.UserRoles.FindAsync(id);
            if (Userrole != null)
            {
                _context.UserRoles.Remove(Userrole);
                _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool UserroleExists(int id)
        {
            return (_context.UserRoles.FindAsync(id).IsCompletedSuccessfully);
        }
    }
}
