namespace SRP.Application.Caching.Message
{
    public interface IMessageEventClient : IMessageEvent
    {
        string ClientId { get; set; }
    }
}