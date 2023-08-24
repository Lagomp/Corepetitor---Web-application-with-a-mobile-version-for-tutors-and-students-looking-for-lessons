using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tutor.Data;
using Tutor.DataTransferObjects;
using Tutor.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tutor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ITutorService _tutorService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ITutorService tutorService)
        {
            _logger = logger;
            _context = context;
            _tutorService = tutorService;
        }

        public async Task<IActionResult> Index(int? s, decimal? p, string l)
        {
            ViewBag.Subjects = await _context.Subjects.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync();
            var data = await (from ss in _context.Subjects
                              join ts in _context.TeacherSubjects on ss.Id equals ts.SubjectId
                              join u in _context.Users on ts.TeacherId equals u.Id
                              select new DashboardTeacherDto
                              {
                                  TeacherId = ts.TeacherId,
                                  TeacherName = u.FirstName + " " + u.LastName,
                                  Availability = ts.IsAvailable,
                                  TeacherSubjects = ss.Name,
                                  TeacherImage = u.ImagePath,
                                  AlreadyEnrollments = _context.Enrollments.Where(d => d.TeacherSubjectId == ts.Id).Count(),
                                  TeacherSubjectId = ts.Id,
                                  SubjectId = ss.Id,
                                  Price = ts.MonthlyFee,
                                  Localization = ts.Localization
                              }).ToListAsync();

            if (s.HasValue)
            {
                data = data.Where(x => x.SubjectId == s.Value).ToList();
            }
            if (p.HasValue)
            {
                data = data.Where(x => x.Price == p.Value).ToList();
            }
            if (!string.IsNullOrEmpty(l))
            {
                data = data.Where(x => x.Localization.ToLower().Contains(l.ToLower())).ToList();
            }
            return View(data);
        }

        public async Task<IActionResult> Users()
        {

            var _users = await _context.Users.ToListAsync();
            var _userRoles = await _context.UserRoles.ToListAsync();
            var _roleId = await _context.Roles.Where(x => x.Name == "Student").Select(d => d.Id).FirstOrDefaultAsync();

            var reqUserIDs = _userRoles.Where(x => x.RoleId == _roleId).Select(x => x.UserId).ToList();

            var users = new List<UserVM>();
            foreach (var item in _users)
            {
                if (reqUserIDs.Contains(item.Id))
                {
                    users.Add(new UserVM
                    {
                        Id = item.Id,
                        Email = item.Email,
                        IsBlocked = item.IsBlocked,
                        Name = item.FirstName + " " + item.LastName
                    });
                }
            }
            return View(users);
        }

        public async Task<IActionResult> Block(string Id, bool b)
        {
            var _user = await _context.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (_user != null)
            {
                _user.IsBlocked = b;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Users));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}