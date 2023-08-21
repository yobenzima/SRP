using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Constants;

public partial class CacheKey
{
    public static string ADDRESSATTRIBUTES_BY_ID_KEY => "SRP.address-attribute.id-{0}";
    public static string ADDRESSATTRIBUTES_BY_PROVINCE => "SRP.address-attribute.province-{0}";
}
