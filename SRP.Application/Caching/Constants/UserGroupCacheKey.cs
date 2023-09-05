using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Constants;

public partial class CacheKey
{
    public static string USERGROUP_BY_ID_KEY => "SRP.user-group.id-{0}";
    public static string USERGROUP_BY_SYSTEMNAME_KEY => "SRP.user-group.system-name-{0}";
}
