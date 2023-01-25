using Angels.HelpDesk.Application.Constants;
using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace Angels.HelpDesk.BusinessLogic.ExtensionMethods
{
    public static class BusinessLogicLayerExtensions
    {
        public static void AddBusinessLogicLayerExtensions(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(EnvironmentVariables.SECRET_KEY),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IUserManagementService, UserManagementService>();
            services.AddSingleton<IDomainListService, DomainListService>();
        }
    }
}
