﻿using MediatR;
using SRP.Application.DTOs.AddressTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.AddressTypes.Requests.Queries
{
    public class GetAddressTypeListRequest : IRequest<List<AddressTypeListDto>>
    {
    }
}
