using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LocalMunicipalities
{
    public interface ILocalMunicipalityDto
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
