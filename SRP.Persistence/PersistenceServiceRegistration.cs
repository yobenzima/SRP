using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;
using SRP.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SRPDbContext>(options =>
                options.UseSqlServer(                    
                    configuration.GetConnectionString("SRPConnection")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
            services.AddScoped<CountryRepository>();
            services.AddScoped<ICountryRepository, CachedCountryRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IBEECertificationTypeRepository, BEECertificationTypeRepository>();
            services.AddScoped<IApplicantTypeRepository, ApplicantTypeRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<ILegalEntityTypeRepository, LegalEntityTypeRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ILocalMunicipalityRepository, LocalMunicipalityRepository>();
            
            return services;
        }
    }
}
