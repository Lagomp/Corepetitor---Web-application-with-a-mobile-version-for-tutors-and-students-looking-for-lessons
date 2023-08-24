namespace Tutor.DataTransferObjects
{
    public class DashboardTeacherDto
    {
        public string TeacherId { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public string TeacherImage { get; set; } = string.Empty;
        public string TeacherSubjects { get; set; } = string.Empty;
        public int AlreadyEnrollments { get; set; }
        public string Availability { get; set; } = string.Empty;
        public int TeacherSubjectId { get; set; }
        public int SubjectId { get; set; }
        public decimal Price { get; set; }
        public string Localization { get; set; } = string.Empty;
    }

    public class UserVM
    {
        public string Id { get; set; }=string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
    }
}
