using System.ComponentModel;

namespace Tutor.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [DisplayName("Nazwa przedmiotu")]
        public string Name { get; set; } = string.Empty;
    }
}
