using Angels.HelpDesk.Domain.Commons;
using Angels.HelpDesk.Domain.Enums;
using Angels.HelpDesk.Domain.Interfaces.Commons;
using Microsoft.Extensions.Logging;
using Opencity.Utils.MongoDB.ApplicationContext;

namespace Angels.HelpDesk.Persistence.Repositories.Commons
{
    public abstract class DomainList<T> : BaseRepository<T>, IDomainList<T> where T : DomainList
    {
        protected DomainList(
            ApplicationDbContext dbContext,
            ILogger<DomainList<T>> logger) : base(dbContext, logger) { }


        public Task<List<T>> FindAllByStatusAsync(Status status = Status.Active)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Status == status);
            return FindManyAsync(filterDefinition);
        }

        public Task<T> FindByIdAndStatusAsync(string id, Status status = Status.Active, bool isNullResultAllowed = false)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Status == status &&
                                                                          item.Id.Equals(id));

            return FindOneAsync(filterDefinition, isNullResultAllowed);
        }
    }
}
