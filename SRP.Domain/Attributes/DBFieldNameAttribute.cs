using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DBFieldNameAttribute : Attribute
    {
        private readonly string mName;
        public DBFieldNameAttribute(string name)
        {
            mName = name;
        }

        public virtual string Name { get { return mName; } }
    }
}
