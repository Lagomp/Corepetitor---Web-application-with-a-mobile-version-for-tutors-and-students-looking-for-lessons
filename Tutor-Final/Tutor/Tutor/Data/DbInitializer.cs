using Microsoft.AspNetCore.Identity;
using Tutor.Models;

namespace Tutor.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void InitializeDatabase()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole
                {
                    ConcurrencyStamp = string.Empty,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
                _context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole
                {
                    ConcurrencyStamp = string.Empty,
                    Name = "Tutor",
                    NormalizedName = "TUTOR"
                });
                _context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole
                {
                    ConcurrencyStamp = string.Empty,
                    Name = "Student",
                    NormalizedName = "STUDENT"
                });
                _context.SaveChanges();
            }

            var admin = (from x in _context.Users
                         join ur in _context.UserRoles on x.Id equals ur.UserId
                         join r in _context.Roles on ur.RoleId equals r.Id
                         where r.Name == "Admin"
                         select x).Count();
            if (admin == 0)
            {
                var _user = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    EmailConfirmed=true,
                    LockoutEnabled=true
                };
                var result = _userManager.CreateAsync(_user, "Abcd@1234").Result;
                if (result.Succeeded)
                {
                    _context.SaveChanges();
                    var ad = _userManager.AddToRoleAsync(_user, "Admin").Result;
                }
                
                var _tutor = new ApplicationUser
                {
                    Email = "tutor@admin.com",
                    UserName = "tutor@admin.com",
                    EmailConfirmed=true,
                    LockoutEnabled=true
                };
                var tutorResult = _userManager.CreateAsync(_tutor, "Abcd@1234").Result;
                if (tutorResult.Succeeded)
                {
                    _context.SaveChanges();
                    var ad = _userManager.AddToRoleAsync(_tutor, "Tutor").Result;
                }
                
                var _student = new ApplicationUser
                {
                    Email = "student@admin.com",
                    UserName = "student@admin.com",
                    EmailConfirmed=true,
                    LockoutEnabled=true
                };
                var studentResult = _userManager.CreateAsync(_student, "Abcd@1234").Result;
                if (studentResult.Succeeded)
                {
                    _context.SaveChanges();
                    var ad = _userManager.AddToRoleAsync(_student, "Student").Result;
                }
            }
        }
    }
}
