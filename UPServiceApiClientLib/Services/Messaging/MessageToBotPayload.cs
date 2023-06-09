namespace UPServiceApiClientLib.Services.Messaging
{
    public class MessageToBotPayload
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SendTo { get; set; }
        public long BotId { get; set; }
        public long TopicId { get; set; }
        public string ContentType { get; set; }
        public string LinkUrl { get; set; }
        public string Parameters { get; set; }
    }
}
