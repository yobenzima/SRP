namespace SRP.Application.Caching.Message;

public interface IMessageEvent
{
    string Key { get; set; }
    int MessageType { get; set; }
}
