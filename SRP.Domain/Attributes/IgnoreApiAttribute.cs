using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property)]
public class IgnoreApiAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property)]
public class IgnoreApiUrlAttribute : Attribute
{
}

