using Angels.HelpDesk.Domain.Interfaces.Models.AuthService;
using Angels.HelpDesk.Domain.Interfaces.Models.DomainLists;
using Angels.HelpDesk.Persistence.Repositories.Models.AuthService;
using Angels.HelpDesk.Persistence.Repositories.Models.DomainLists;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opencity.Utils.MongoDB.ApplicationContext;
using Opencity.Utils.MongoDB.ExtentionsMethods;
using Opencity.Utils.MongoDB.Settings;

namespace Angels.HelpDesk.Persistence.ExtentionMethods
{
    public static class PersistenceLayerExtensions
    {
        public static void AddPersistenceLayerExtensions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMongo(configuration.GetSection($"{nameof(DbSettings)}").Get<DbSettings>()));

            
            // UserManagement
            services.AddSingleton<IUserRepository, UserRepository>();

            // AuthService
            services.AddSingleton<IAuthUserRepository, AuthUserRepository>();

            // DomainList
            services.AddSingleton<IIdentificationTypeRepository, IdentificationTypeRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
        }
    }
}
