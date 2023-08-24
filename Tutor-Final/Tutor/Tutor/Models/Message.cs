namespace Tutor.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string ToId { get; set; } = string.Empty;
        public string FromId { get; set; }=string.Empty;
        public string MessageText { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
