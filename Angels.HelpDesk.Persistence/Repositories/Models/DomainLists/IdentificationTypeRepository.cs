using Angels.HelpDesk.Domain.Interfaces.Models.DomainLists;
using Angels.HelpDesk.Domain.Models.DomainLists;
using Angels.HelpDesk.Persistence.Repositories.Commons;
using Microsoft.Extensions.Logging;
using Opencity.Utils.MongoDB.ApplicationContext;

namespace Angels.HelpDesk.Persistence.Repositories.Models.DomainLists
{
    public class IdentificationTypeRepository : DomainList<IdentificationType>, IIdentificationTypeRepository
    {
        public IdentificationTypeRepository(
            ApplicationDbContext dbContext,
            ILogger<DomainList<IdentificationType>> logger) : base(dbContext, logger) { }
    }
}
