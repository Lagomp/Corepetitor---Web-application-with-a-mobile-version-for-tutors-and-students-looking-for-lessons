namespace Tutor.DataTransferObjects
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public DateTime MessageTime { get; set; }
        public bool IsFromMessage { get; set; }
    }
}
