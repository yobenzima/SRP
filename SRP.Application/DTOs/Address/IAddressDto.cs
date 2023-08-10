using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Address
{
    public interface IAddressDto
    {
        /// <summary>
        /// Type of address e.g. Home, Work, etc.
        /// </summary>
        public Guid AddressTypeId { get; set; }
        /// <summary>
        /// Index for sorting
        /// </summary>
        public int SlotIndex { get; set; }
        /// <summary>
        /// Floor number or name
        /// </summary>
        public string? Floor { get; set; }
        /// <summary>
        /// Building number or name
        /// </summary>
        public string? Building { get; set; }
        /// <summary>
        /// Street number or name
        /// </summary>
        public string? Street { get; set; }
        /// <summary>
        /// Name of the city
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// Postal code
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// Id of the location
        /// </summary>
        public Guid? LocationId { get; set; }
        /// <summary>
        /// Id of the province
        /// </summary>
        public Guid? ProvinceId { get; set; }
        /// <summary>
        /// Id of the country
        /// </summary>
        public Guid? CountryId { get; set; }
    }
}
