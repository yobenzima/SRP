namespace SRP.Application.Caching.Message;

public interface IMessageSubscriber
{
    Task SubscribeAsync();
}
