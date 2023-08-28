using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Message;

public interface IMessageBus : IMessagePublisher, IMessageSubscriber
{
    void OnSubscriptionChanged(IMessageEvent message);
}
