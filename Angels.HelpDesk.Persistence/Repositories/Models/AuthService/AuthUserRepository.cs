using Angels.HelpDesk.Domain.Enums;
using Angels.HelpDesk.Domain.Interfaces.Models.AuthService;
using Angels.HelpDesk.Domain.Models.AuthService;
using Angels.HelpDesk.Persistence.Repositories.Commons;
using Microsoft.Extensions.Logging;
using Opencity.Utils.MongoDB.ApplicationContext;
using Opencity.Utils.MongoDB.Infrastructure.Persistence.Common;

namespace Angels.HelpDesk.Persistence.Repositories.Models.AuthService
{
    public class AuthUserRepository : BaseRepository<AuthUser>, IAuthUserRepository
    {
        public AuthUserRepository(
            ApplicationDbContext dbContext,
            ILogger<CoreRepository<AuthUser>> logger) : base(dbContext, logger) { }


        public Task<AuthUser> FindOneByEmailAndStatus(string email, Status status = Status.Active)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Email.Equals(email) &&
                                                                          item.Status == status);

            return FindOneAsync(filterDefinition);
        }
    }
}
