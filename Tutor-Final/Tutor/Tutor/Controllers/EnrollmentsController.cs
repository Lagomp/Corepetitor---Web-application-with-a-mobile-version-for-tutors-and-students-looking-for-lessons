using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutor.Data;
using Tutor.Models;

namespace Tutor.Controllers
{
    [Authorize]
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITutorService _tutorService;

        public EnrollmentsController(ApplicationDbContext context, ITutorService tutorService)
        {
            _context = context;
            _tutorService = tutorService;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var currentUser = await _tutorService.GetCurrentUser(User.Identity.Name);
            if (User.IsInRole("Student"))
            {
                var applicationDbContext = _context.Enrollments.Where(x => x.StudentId == currentUser.UserId).Include(e => e.Student).Include(e => e.TeacherSubject);
                return View(await applicationDbContext.ToListAsync());
            }
            else if (User.IsInRole("Tutor"))
            {
                var applicationDbContext = _context.Enrollments.Where(x => x.TeacherSubject.TeacherId == currentUser.UserId).Include(e => e.Student).Include(e => e.TeacherSubject);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.Enrollments.Include(e => e.Student).Include(e => e.TeacherSubject);
                return View(await applicationDbContext.ToListAsync());
            }
        }

        
                                 
        public async Task<IActionResult> Cancel(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                enrollment.Status = EnrollmentStatus.Cancelled;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.TeacherSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }



        // GET: Enrollments/Create
        public async Task<IActionResult> Create(int tsId)
        {
            var currentUser = await _tutorService.GetCurrentUser(User.Identity.Name);
            if (currentUser.IsBlocked)
                return RedirectToAction("Error", "Home");

            ViewData["StudentId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");

            var teacherSubjects = await _context.TeacherSubjects.Include(e => e.Subject).Select(x => new
            {
                Id = x.Id,
                Name = x.Subject.Name
            }).ToListAsync();

            ViewData["TeacherSubjectId"] = new SelectList(teacherSubjects, "Id", "Name", tsId);
            ViewBag.Status = new List<SelectListItem>
            {
                new SelectListItem{Text=EnrollmentStatus.Started.ToString(), Value=EnrollmentStatus.Started.ToString()},
                new SelectListItem{Text=EnrollmentStatus.Completed.ToString(), Value=EnrollmentStatus.Completed.ToString()}
            };
            return View(new Enrollment() { TeacherSubjectId = tsId });
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            var currentUser = await _tutorService.GetCurrentUser(User.Identity.Name);

            var enr = await _context.Enrollments.Where(x =>
            x.TeacherSubjectId == enrollment.TeacherSubjectId
            && x.StartDate >= enrollment.StartDate
            && enrollment.StartDate <= x.EndDate).AnyAsync();

            if (enr)
            {
                ViewBag.Error = "Nie możesz zarezerwoać tego kursu. Albo Ty, albo ktoś inny już to zrobił";
                return View(enrollment);
            }
            enrollment.Status = EnrollmentStatus.Started;
            enrollment.StudentId = currentUser.UserId;
            _context.Add(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewBag.Status = new List<SelectListItem>
            {
                new SelectListItem{Text=EnrollmentStatus.Started.ToString(), Value=EnrollmentStatus.Started.ToString()},
                new SelectListItem{Text=EnrollmentStatus.Completed.ToString(), Value=EnrollmentStatus.Completed.ToString()}
            };
            ViewData["StudentId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", enrollment.StudentId);
            ViewData["TeacherSubjectId"] = new SelectList(_context.TeacherSubjects, "Id", "Id", enrollment.TeacherSubjectId);
            ViewBag.Status = new List<SelectListItem>
            {
                new SelectListItem{Text=EnrollmentStatus.Started.ToString(), Value=EnrollmentStatus.Started.ToString()},
                new SelectListItem{Text=EnrollmentStatus.Completed.ToString(), Value=EnrollmentStatus.Completed.ToString()}
            };
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Enrollment enrollment)
        {
            try
            {
                _context.Update(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.TeacherSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enrollments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Enrollments'  is null.");
            }
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}
