using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Statuses
{
    public interface IStatusDto
    {
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
