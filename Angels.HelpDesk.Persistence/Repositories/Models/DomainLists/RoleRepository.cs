using Angels.HelpDesk.Domain.Interfaces.Models.DomainLists;
using Angels.HelpDesk.Domain.Models.DomainLists;
using Angels.HelpDesk.Persistence.Repositories.Commons;
using Microsoft.Extensions.Logging;
using Opencity.Utils.MongoDB.ApplicationContext;

namespace Angels.HelpDesk.Persistence.Repositories.Models.DomainLists
{
    public class RoleRepository : DomainList<Role>, IRoleRepository
    {
        public RoleRepository(
            ApplicationDbContext dbContext,
            ILogger<DomainList<Role>> logger) : base(dbContext, logger) { }
    }
}
