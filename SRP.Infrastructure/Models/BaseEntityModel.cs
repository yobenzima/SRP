using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Models
{
    public class BaseEntityModel : BaseModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual Guid Id { get; set; }
    }
}
