using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DbProviders;

public partial record Provider
{
    public static readonly Provider SQLServer = new(nameof(SQLServer), typeof(Data.SQLServer.Marker).Assembly.GetName().Name!);
}
