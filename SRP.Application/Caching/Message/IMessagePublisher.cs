namespace SRP.Application.Caching.Message;

public interface IMessagePublisher
{
    Task PublishAsync<TMessage>(TMessage message) where TMessage : IMessageEvent;
}
