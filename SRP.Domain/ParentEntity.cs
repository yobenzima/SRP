using SRP.Domain.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SRP.SharedKernel.Attributes;

namespace SRP.Domain
{
    public abstract class ParentEntity
    {
        protected ParentEntity()
        {
            mId = UniqueIdentifier.New;
        }

        [DBFieldName("Id")]
        [Key]
        public Guid Id
        {
            get { return mId; }
            set
            {
                if(mId == Guid.Empty)
                    mId = UniqueIdentifier.New;
                else
                    mId = value;
            }
        }

        private Guid mId;
    }
}
