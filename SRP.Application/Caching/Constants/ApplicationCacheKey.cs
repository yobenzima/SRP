using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Constants;

public partial class CacheKey
{
    public static string APPLICATIONATTRIBUTES_BY_ID_KEY => "SRP.application-attribute.id-{0}";
    public static string APPLICATIONATTRIBUTES_BY_APPLICANT_ID_KEY => "SRP.application-attribute.applicant.id-{0}";
}
