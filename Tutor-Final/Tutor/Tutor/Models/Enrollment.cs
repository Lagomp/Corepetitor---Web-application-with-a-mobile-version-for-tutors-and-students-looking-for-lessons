using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        [DisplayName("Numer identyfikacyjny studenta")]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey("TeacherSubject")]
        [DisplayName("Numer identyfikacyjny przedmiotu")]
        public int TeacherSubjectId { get; set; }
        [DisplayName("Data rozpoczęcia")]
        public DateTime StartDate { get; set; }
        [DisplayName("Data zakończenia")]
        public DateTime EndDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        public virtual ApplicationUser Student { get; set; }
        [DisplayName("Numer identyfikacyjny przedmiotu")]
        public virtual TeacherSubject TeacherSubject { get; set; }
    }

    public enum EnrollmentStatus
    {
        Started = 1,
        Completed = 2,
        Cancelled = 3,
        Started0 = 0
    }

    public class Rating
    {
        public int Id { get; set; }
        [DisplayName("Komentarz")]
        public string Feedback { get; set; } = string.Empty;
        [ForeignKey("Enrollment")]
        public int EnrollmentId { get; set; }
        [DisplayName("Ocena")]
        public int Stars { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }

}
