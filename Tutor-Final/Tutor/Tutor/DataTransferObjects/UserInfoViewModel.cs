namespace Tutor.DataTransferObjects
{
    public class UserInfoViewModel
    {
        public string UserName { get; set;}=string.Empty;
        public string UserEmail { get; set;}=string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserImage { get; set; }=string.Empty;
        public string UserRole { get; set; }=string.Empty;
        public string FullName { get; set; }=string.Empty;
        public bool IsBlocked { get; set; }

    }
}
