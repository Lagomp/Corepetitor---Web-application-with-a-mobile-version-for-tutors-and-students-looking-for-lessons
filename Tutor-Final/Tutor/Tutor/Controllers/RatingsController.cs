using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutor.Data;
using Tutor.Models;

namespace Tutor.Controllers
{
    public class RatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ratings
        public async Task<IActionResult> Index(string tId)
        {
            var enrollmentIDs = await (from u in _context.Users
                                       join ts in _context.TeacherSubjects on u.Id equals ts.TeacherId
                                       join en in _context.Enrollments on ts.Id equals en.TeacherSubjectId
                                       where u.Id == tId
                                       select en.Id).Distinct().ToListAsync();

            var applicationDbContext = _context.Ratings.Where(x => enrollmentIDs.Contains(x.EnrollmentId)).Include(r => r.Enrollment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ratings == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings
                .Include(r => r.Enrollment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create(int eId)
        {
            var ratings = new List<SelectListItem>
            {
                new SelectListItem {Text="1", Value="1"},
                new SelectListItem {Text="2", Value="2"},
                new SelectListItem {Text="3", Value="3"},
                new SelectListItem {Text="4", Value="4"},
                new SelectListItem {Text="5", Value="5"},
            };
            ViewBag.Ratings = ratings;
            return View(new Rating() { EnrollmentId = eId });
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rating rating)
        {
            var skipped = ModelState.Keys.Where(key => key.StartsWith("Enrollment"));
            foreach (var key in skipped)
                ModelState.Remove(key);

            if (ModelState.IsValid)
            {
                _context.Add(rating);

                var enrollment = await _context.Enrollments.FindAsync(rating.EnrollmentId);
                if (enrollment != null)
                    enrollment.Status = EnrollmentStatus.Completed;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Enrollments");
            }
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id", rating.EnrollmentId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ratings == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id", rating.EnrollmentId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Feedback,EnrollmentId,Stars")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
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
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id", rating.EnrollmentId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ratings == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings
                .Include(r => r.Enrollment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ratings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ratings'  is null.");
            }
            var rating = await _context.Ratings.FindAsync(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return _context.Ratings.Any(e => e.Id == id);
        }
    }
}
