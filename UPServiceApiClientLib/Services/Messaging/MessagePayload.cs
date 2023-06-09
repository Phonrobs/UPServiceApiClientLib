namespace UPServiceApiClientLib.Services.Messaging
{
    public class MessagePayload
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SendTo { get; set; }
        public long TopicId { get; set; }
        public string LinkUrl { get; set; }
    }
}
