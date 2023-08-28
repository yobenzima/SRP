using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Message;

public enum MessageEventType
{
    RemoveKey = 0,
    RemoveByPrefix = 1,
    ClearCache = 2
}
