using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor.Models
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        [DisplayName("Numer identyfikacyjny korepetytora")]
        public string TeacherId { get; set; }
        [ForeignKey("Subject")]
        [DisplayName("Przedmiot")]
        public int SubjectId { get; set; }
        [DisplayName("Forma zajęć")]
        public string IsAvailable { get; set; } = string.Empty;
        [DisplayName("Cena za spotkanie")]
        public decimal MonthlyFee { get; set; }
        [DisplayName("Ilość zarezerwowanych spotkań")]
        public int TotalEnrollments { get; set; }
        [DisplayName("Lokalizacja")]
        public string Localization { get; set; } = string.Empty;
        [DisplayName("Numer identyfikacyjny przedmiotu")]
        public virtual Subject Subject { get; set; }
    }
}
