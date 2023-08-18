using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Statuses.Validators
{
    public class CreateStatusDtoValidator : AbstractValidator<CreateStatusDto>
    {
        private readonly IStatusRepository mStatusRepository;

        public CreateStatusDtoValidator(IStatusRepository statusRepository)
        {
            mStatusRepository = statusRepository;

            Include(new IStatusDtoValidator(mStatusRepository));
        }
    }
}
