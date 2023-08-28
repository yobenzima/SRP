using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Constants;

public partial class CacheKey
{
    public static string COUNTRYATTRIBUTES_BY_ID_KEY => "srp.country-attribute.id-{0}";
    public static string COUNTRYATTRIBUTES_ALL => "srp.country-attribute.all";

}
