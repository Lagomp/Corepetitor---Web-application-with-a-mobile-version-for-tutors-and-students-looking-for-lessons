using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tutor.Models;

namespace Tutor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }           
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public  DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        
    }
}