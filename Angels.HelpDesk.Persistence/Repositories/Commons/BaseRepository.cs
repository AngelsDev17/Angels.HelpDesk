using Angels.HelpDesk.Domain.Interfaces.Commons;
using Microsoft.Extensions.Logging;
using Opencity.Utils.MongoDB.ApplicationContext;
using Opencity.Utils.MongoDB.Infrastructure.Persistence.Common;

namespace Angels.HelpDesk.Persistence.Repositories.Commons
{
    public abstract class BaseRepository<T> : CoreRepository<T>, IBaseRepository<T> where T : class
    {
        protected BaseRepository(
            ApplicationDbContext dbContext,
            ILogger<CoreRepository<T>> logger,
            bool cipher = false,
            params (string cipherObject, string type)[] fields) : base(dbContext, logger, cipher, fields) { }

        public new Task<List<T>> FindAllAsync() => base.FindAllAsync();
        public new Task<List<string>> InsertManyAsync(List<T> entities) => base.InsertManyAsync(entities);
        public new Task<string> InsertOneAsync(T entity) => base.InsertOneAsync(entity);
        public new Task DeleteOneAsync(string id) => base.DeleteOneAsync(id);
    }
}
