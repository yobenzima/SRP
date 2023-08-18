using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Titles
{
    public interface ITitleDto
    {
        string Code { get; set; }

        string Description { get; set; }
    }
}
