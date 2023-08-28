using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Contracts.Security;
using SRP.Application.Models;
using SRP.Infrastructure.Mail;
using SRP.Infrastructure.Security;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IPermissionProvider, PermissionProvider>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IUserGroupService, UserGroupService>();

            return services;
        }
    }
}
