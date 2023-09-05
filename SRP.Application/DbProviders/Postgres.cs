using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DbProviders;

public partial record Provider(string Name, string Assembly)
{
    public static readonly Provider Postgres = new(nameof(Postgres), typeof(Data.PostgreSQL.Marker).Assembly.GetName().Name!);
}