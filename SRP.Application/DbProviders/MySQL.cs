using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DbProviders;

public partial record Provider
{
    public static readonly Provider MySQL = new(nameof(MySQL), typeof(Data.MySQL.Marker).Assembly.GetName().Name!);
}
