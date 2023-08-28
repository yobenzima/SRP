using SRP.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRP.Infrastructure.Models;

public class BaseModel
{
    public BaseModel()
    {
        PostInitialize();
        UserFields = new List<UserField>();
    }

    protected virtual void PostInitialize()
    {
    }

    public IList<UserField> UserFields { get; set; }
}
