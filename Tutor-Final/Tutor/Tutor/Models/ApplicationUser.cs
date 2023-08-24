using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Tutor.Models
{
    public class ApplicationUser:IdentityUser
    {
        [DisplayName("Imię")]
        public string FirstName { get; set; }=string.Empty;
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }= string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        [DisplayName("Czy użytkownik jest zablokowany?")]
        public bool IsBlocked { get; set; } = false;
        [DisplayName("Opis")]
        public string Description { get; set; } = string.Empty;
        [DisplayName("Edukacja")]
        public string Education { get; set; } = string.Empty;
        [DisplayName("Doświadczenie")]
        public int Experience { get; set; } = 0;

    }
}
