using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        private readonly SRPDbContext mDbContext;

        public CountryRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
            DoNothing();
        }

        // This method is used to remove warning IDE0052: Remove unread private members
        private void DoNothing()
        {
            Console.WriteLine(mDbContext.Database.ProviderName);
        }
    }
}
