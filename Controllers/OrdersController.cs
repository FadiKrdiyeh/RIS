using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ris2022.Data;
using Ris2022.Data.Models;
using Ris2022.MllpHl7Client;
using Ris2022.Resources;

namespace Ris2022.Controllers
{
    public class OrdersController : Controller
    {
        private readonly RisDBContext _context;
        private readonly UserManager<RisAppUser> _userManager;

        public OrdersController(RisDBContext context,UserManager<RisAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var risDBContext = _context.Orders
                .Include(o => o.Ordertype)
                .Include(o => o.clinic)
                .Include(o => o.dept)
                .Include(o => o.modality)
                .Include(o => o.modalitytype)
                .Include(o => o.patient)
                .Include(o => o.paytype)
                .Include(o => o.proceduretype)
                .Include(o => o.reason)
                .Include(o=>o.RisAppDoctor);
             return View(await risDBContext.ToListAsync());
        }

        // GET: Orders/IndexSchudledOrder

        public async Task<IActionResult> IndexSchudledOrder()
        {
            var risDBContext = _context.Orders
                .Include(o => o.Ordertype)
                .Include(o => o.clinic)
                .Include(o => o.dept)
                .Include(o => o.modality)
                .Include(o => o.modalitytype)
                .Include(o => o.patient)
                .Include(o => o.paytype)
                .Include(o => o.proceduretype)
                .Include(o => o.reason)
                .Include(o => o.RisAppDoctor);
            return View(await risDBContext.ToListAsync());
        }



        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Ordertype)
                .Include(o => o.clinic)
                .Include(o => o.dept)
                .Include(o => o.modality)
                .Include(o => o.modalitytype)
                .Include(o => o.patient)
                .Include(o => o.paytype)
                .Include(o => o.proceduretype)
                .Include(o => o.reason)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/DetailsSchudledOrder/5

        public async Task<IActionResult> DetailsSchudledOrder(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Ordertype)
                .Include(o => o.clinic)
                .Include(o => o.dept)
                .Include(o => o.modality)
                .Include(o => o.modalitytype)
                .Include(o => o.patient)
                .Include(o => o.paytype)
                .Include(o => o.proceduretype)
                .Include(o => o.reason)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create(int patientId)
        {
            Order order = new()
            {
                Patientid = patientId,
                Studyid = "1.2.4.0.13.1.4.2252867." + patientId
            };
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName");
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name");
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname");
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName);
            return View(order);
        }

        // function to get modalities names
        [HttpPost]
        public IActionResult getDeptModalities(int patientId)
        {
            Order order = new()
            {
                Patientid = patientId,
                Studyid = "1.2.4.0.13.1.4.2252867." + patientId
            };

            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name");
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName);

            return View(order);
        }


        // GET: Orders/CreateSchudledOrder
        public IActionResult CreateSchudledOrder(int patientId)
        {
            Order order = new()
            {
                Patientid = patientId,
                Studyid = "1.2.4.0.13.1.4.2252867." + patientId
            };
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName");
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name");
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname");
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName);
            return View(order);

        }

        // post: Orders/Convert Arabic Text toEnglish

        [HttpPost]

        public string toEnglish(string araString)
        {
            string result = "";
            StringBuilder sb = new StringBuilder(araString);
            #region Mapping letters
            sb.Replace("ا", "a");
            sb.Replace(" ", " ");

            sb.Replace("ء", "a");
            sb.Replace("ؤ", "ou");
            sb.Replace("ئ", "e");
            sb.Replace("أ", "a");
            sb.Replace("ة", "a");
            sb.Replace("إ", "e");
            sb.Replace("ى", "a");
            sb.Replace("ب", "b");
            sb.Replace("ت", "t");
            sb.Replace("ث", "th");
            sb.Replace("ج", "g");
            sb.Replace("ح", "h");
            sb.Replace("خ", "kh");
            sb.Replace("د", "d");
            sb.Replace("ذ", "th");
            sb.Replace("ر", "r");
            sb.Replace("ز", "z");
            sb.Replace("س", "s");
            sb.Replace("ش", "sh");
            sb.Replace("ص", "s");
            sb.Replace("ض", "d");
            sb.Replace("ط", "t");
            sb.Replace("ظ", "z");
            sb.Replace("ع", "a");
            sb.Replace("غ", "g");
            sb.Replace("ف", "f");
            sb.Replace("ق", "k");
            sb.Replace("ك", "k");
            sb.Replace("ل", "l");
            sb.Replace("م", "m");
            sb.Replace("ن", "n");
            sb.Replace("ه", "h");
            sb.Replace("و", "w");
            sb.Replace("ي", "y");
            #endregion
            result = sb.ToString();
            return result;
        }

        [HttpPost]

        public Boolean isArabic(string t)
        {
            Boolean s = false;
            if (t != null)
                if (Regex.IsMatch(t, @"\p{IsArabic}"))
                    s = true;
            return s;
        }



        // POST: Orders/CreateSchudledOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSchudledOrder(Order order)
        {
            Patient patient = _context.Patients.SingleOrDefault(p => p.Id == order.Patientid);
            order.modality = _context.Modalities.SingleOrDefault(m => m.Id == order.Modalityid);
            order.Accessionnumber = int.Parse(patient.Id + DateTime.Now.ToString("ssmm"));
            order.InsertuserName = User.FindFirstValue(ClaimTypes.Name);
            //order.Startdate = DateTime.Now;
            order.proceduretype = _context.Proceduretypes.SingleOrDefault(proc => proc.Id == order.Proceduretypeid);
            //order.Startdate = DateTime.Now.ToUniversalTime();
            HL7message hL7Message = new()
            {
                studyId = order.Studyid,
                patientGivenId = patient.Givenid,
                aeTitle = order.modality.Aetitle,
                sStationName = order.modality.Name,
                obsOrderPFNum = patient.Id,
                patientFirstName = patient.Firstname,
                patientLastName = patient.Lastname,
                modalityName = order.modality.Name,
                startDateTime = DateTime.Now.ToString("yyyyMMddHHmmss"),
                //startDateTime = DateTime.ParseExact(order.Startdate.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString(),
                procedureId = order.Proceduretypeid.Value,
                procedureName = order.proceduretype.Nameen
            };
            if (ModelState.IsValid && Hl7Client.SendHl7Msg(hL7Message))
                //if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName",order.InsertuserName);
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName, order.Ordertypeid);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName, order.Clinicid);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName, order.Departmentid);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name", order.Modalityid);
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName, order.Modalitytypeid);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname", order.Patientid);
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName, order.Paytypeid);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName, order.Proceduretypeid);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName, order.Reasonid);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Order order)
        {
            Patient patient = _context.Patients.SingleOrDefault(p => p.Id == order.Patientid);
            order.modality = _context.Modalities.SingleOrDefault(m => m.Id == order.Modalityid);
            order.Accessionnumber = int.Parse(patient.Id + DateTime.Now.ToString("ssmm"));
            order.InsertuserName = User.FindFirstValue(ClaimTypes.Name);
            //order.Startdate = DateTime.Now;
            order.proceduretype = _context.Proceduretypes.SingleOrDefault(proc => proc.Id == order.Proceduretypeid);
            //order.Startdate = DateTime.Now.ToUniversalTime();
            HL7message hL7Message = new()
            {
                studyId = order.Studyid,
                patientGivenId = patient.Givenid,
                aeTitle = order.modality.Aetitle,
                sStationName = order.modality.Name,
                obsOrderPFNum = patient.Id,
                patientFirstName = patient.Firstname,
                patientLastName = patient.Lastname,
                modalityName = order.modality.Name,
                startDateTime = DateTime.Now.ToString("yyyyMMddHHmmss"),
                //startDateTime = DateTime.ParseExact(order.Startdate.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString(),
                procedureId = order.Proceduretypeid.Value,
                procedureName = order.proceduretype.Nameen
            };
            if (ModelState.IsValid && Hl7Client.SendHl7Msg(hL7Message))
            //if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName", order.InsertuserName);
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName, order.Ordertypeid);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName, order.Clinicid);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName, order.Departmentid);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name", order.Modalityid);
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName, order.Modalitytypeid);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname", order.Patientid);
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName, order.Paytypeid);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName, order.Proceduretypeid);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName, order.Reasonid);
            return View(order);
        }




        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName",order.InsertuserName);
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName, order.Ordertypeid);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName, order.Clinicid);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName, order.Departmentid);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name", order.Modalityid);
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName, order.Modalitytypeid);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname", order.Patientid);
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName, order.Paytypeid);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName, order.Proceduretypeid);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName, order.Reasonid);
            return View(order);
        }

        // GET: Orders/EditSchudledOrder/5 

        public async Task<IActionResult> EditSchudledOrder(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName", order.InsertuserName);
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName, order.Ordertypeid);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName, order.Clinicid);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName, order.Departmentid);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name", order.Modalityid);
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName, order.Modalitytypeid);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname", order.Patientid);
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName, order.Paytypeid);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName, order.Proceduretypeid);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName, order.Reasonid);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Patientid,Modalityid,Proceduretypeid,Studyid,Startdate,Enddate,Statusid,Doctorid,Autoexpiredate,Accessionnumber,Departmentid,Documentid,Ordertypeid,Insertdate,InsertuserName,Reasonid,UpdateuserName,Updatedate,Paytypeid,Payreasonid,Clinicid,Modalitytypeid")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName", order.InsertuserName);
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName, order.Ordertypeid);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName, order.Clinicid);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName, order.Departmentid);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name", order.Modalityid);
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName, order.Modalitytypeid);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname", order.Patientid);
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName, order.Paytypeid);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName, order.Proceduretypeid);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName, order.Reasonid);
            return View(order);
        }

        // POST: Orders/EditSchudledOrder/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditSchudledOrder(int id, [Bind("Id,Patientid,Modalityid,Proceduretypeid,Studyid,Startdate,Enddate,Statusid,Doctorid,Autoexpiredate,Accessionnumber,Departmentid,Documentid,Ordertypeid,Insertdate,InsertuserName,Reasonid,UpdateuserName,Updatedate,Paytypeid,Payreasonid,Clinicid,Modalitytypeid")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Doctorid"] = new SelectList(_userManager.Users.Where(user => user.Isdoctor == true), "Id", "UserName", order.InsertuserName);
            ViewData["Ordertypeid"] = new SelectList(_context.Ordetypes, "Id", Resource.ENARName, order.Ordertypeid);
            ViewData["Clinicid"] = new SelectList(_context.Clinics, "Id", Resource.ENARName, order.Clinicid);
            ViewData["Departmentid"] = new SelectList(_context.Departments, "Id", Resource.ENARName, order.Departmentid);
            ViewData["Modalityid"] = new SelectList(_context.Modalities, "Id", "Name", order.Modalityid);
            ViewData["Modalitytypeid"] = new SelectList(_context.Modalitytypes, "Id", Resource.ENARName, order.Modalitytypeid);
            ViewData["Patientid"] = new SelectList(_context.Patients, "Id", "Firstname", order.Patientid);
            ViewData["Paytypeid"] = new SelectList(_context.Paytypes, "Id", Resource.ENARName, order.Paytypeid);
            ViewData["Proceduretypeid"] = new SelectList(_context.Proceduretypes, "Id", Resource.ENARName, order.Proceduretypeid);
            ViewData["Reasonid"] = new SelectList(_context.Reasons, "Id", Resource.ENARName, order.Reasonid);
            return View(order);
        }


        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Ordertype)
                .Include(o => o.clinic)
                .Include(o => o.dept)
                .Include(o => o.modality)
                .Include(o => o.modalitytype)
                .Include(o => o.patient)
                .Include(o => o.paytype)
                .Include(o => o.proceduretype)
                .Include(o => o.reason)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/DeleteSchudledOrder/5 

        public async Task<IActionResult> DeleteSchudledOrder(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Ordertype)
                .Include(o => o.clinic)
                .Include(o => o.dept)
                .Include(o => o.modality)
                .Include(o => o.modalitytype)
                .Include(o => o.patient)
                .Include(o => o.paytype)
                .Include(o => o.proceduretype)
                .Include(o => o.reason)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'RisDBContext.orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteSchudledOrder")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteSchudledOrder(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'RisDBContext.orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSchudledOrder));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }


}
