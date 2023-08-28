using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Message;

public class CacheMessageEvent
{
    public string ClientId { get; set; } = null!;
    public string Key { get; set; } = null!;
    public int MessageType { get; set; }
}
