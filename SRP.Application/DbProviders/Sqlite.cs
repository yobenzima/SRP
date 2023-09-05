using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DbProviders;

public partial record Provider
{
    public static readonly Provider Sqlite = new(nameof(Sqlite), typeof(Data.Sqlite.Marker).Assembly.GetName().Name!);
}
