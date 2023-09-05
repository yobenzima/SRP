using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Contracts.Persistence;
using SRP.Persistence.Repositories;
using SRP.Application.DbProviders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;


namespace SRP.Persistence
{
    public static class PersistenceServiceRegistration
    {
        private static string? mConnectionStr;

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SRPDbContext>(dbContextOptionsBuilder =>
            {
                var tProvider = configuration.GetValue("provider", Provider.SQLServer.Name);

                if(tProvider == Provider.Sqlite.Name)
                {
                    dbContextOptionsBuilder.UseSqlite(
                        configuration.GetConnectionString(Provider.Sqlite.Name)!,
                        x => x.MigrationsAssembly(Provider.Sqlite.Assembly)
                    );
                    mConnectionStr = configuration.GetConnectionString(Provider.Sqlite.Name)!;
                }
                if(tProvider == Provider.SQLServer.Name)
                {
                    dbContextOptionsBuilder.UseSqlServer(
                        configuration.GetConnectionString(Provider.SQLServer.Name)!,
                        x => x.MigrationsAssembly(Provider.SQLServer.Assembly)
                    );
                    mConnectionStr = configuration.GetConnectionString(Provider.SQLServer.Name)!;
                }
                if(tProvider == Provider.Postgres.Name)
                {
                    dbContextOptionsBuilder.UseNpgsql(
                        configuration.GetConnectionString(Provider.Postgres.Name)!,
                        x => x.MigrationsAssembly(Provider.Postgres.Assembly)
                    );
                    mConnectionStr = configuration.GetConnectionString(Provider.Postgres.Name)!;
                }
                if(tProvider == Provider.MySQL.Name)
                {
                    dbContextOptionsBuilder.UseMySQL(
                        configuration.GetConnectionString(Provider.MySQL.Name)!,
                        x => x.MigrationsAssembly(Provider.MySQL.Assembly)
                    );
                    mConnectionStr = configuration.GetConnectionString(Provider.MySQL.Name)!;
                }
            });
            

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
            services.AddScoped<CountryRepository>();
            /*
             * services.AddScoped<ICountryRepository, CachedCountryRepository>();
             * 
             * Can also be "decorated" as follows:
             * 
             * TODO: Investigate using LazyCache instead of IMemoryCache.
             */
            services.AddScoped<ICountryRepository>(c => new CachedCountryRepository(c.GetRequiredService<SRPDbContext>(), c.GetRequiredService<CountryRepository>(), c.GetRequiredService<ICacheBase>()));
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IBEECertificationTypeRepository, BEECertificationTypeRepository>();
            services.AddScoped<IApplicantTypeRepository, ApplicantTypeRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<ILegalEntityTypeRepository, LegalEntityTypeRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ILocalMunicipalityRepository, LocalMunicipalityRepository>();
            services.AddScoped<IPermissionActionRepository, PermissionActionRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
      
            return services;
        }
    }
}
