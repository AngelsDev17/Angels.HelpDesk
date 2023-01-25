using Angels.HelpDesk.Domain.Enums;
using Angels.HelpDesk.Domain.Interfaces.Models.AuthService;
using Angels.HelpDesk.Domain.Models.UserManagement;
using Angels.HelpDesk.Persistence.Repositories.Commons;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Opencity.Utils.MongoDB.ApplicationContext;
using Opencity.Utils.MongoDB.Infrastructure.Persistence.Common;

namespace Angels.HelpDesk.Persistence.Repositories.Models.AuthService
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(
            ApplicationDbContext dbContext,
            ILogger<CoreRepository<User>> logger) : base(dbContext, logger) { }


        public Task<User> FindOneByEmailAndStatus(string email, Status status = Status.Active)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Email.Equals(email) &&
                                                                          item.Status == status);

            return FindOneAsync(filterDefinition);
        }
        public Task<long> CountByEmailOrIdentification(string email, string identification)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Email.Equals(email) ||
                                                                          item.Identification.Value.Equals(identification));

            return CountAsync(filterDefinition);
        }

        public Task<List<User>> FindAllByStatus(Status status = Status.Active)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Status == status);
            return FindManyAsync(filterDefinition);
        }
        public Task<User> FindOneByIdAndStatus(string id, Status status = Status.Active)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Id.Equals(id) &&
                                                                          item.Status == status);

            return FindOneAsync(filterDefinition);
        }
        public Task ChangeStatusByIdAndStatus(string userId, Status status)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Id.Equals(userId) &&
                                                                          item.Status != status);

            var updateDefinition = _updateDefinitionBuilder.Set(item => item.Status, status);

            return UpdateOneAsync(filterDefinition, updateDefinition);
        }
        public Task UpdateUserData(User user, Status status = Status.Active)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Id.Equals(user.Id) &&
                                                                          item.Status == status);

            var updateDefinition = _updateDefinitionBuilder.Set(item => item.Name, user.Name)
                                                           .Set(item => item.Surname, user.Surname)
                                                           .Set(item => item.Identification, user.Identification)
                                                           .Set(item => item.PhoneNumber, user.PhoneNumber)
                                                           .Set(item => item.Address, user.Address)
                                                           .Set(item => item.Role, user.Role);

            return UpdateOneAsync(filterDefinition, updateDefinition);
        }
        public Task DeleteUserByIdAndStatus(string userId, Status status = Status.Inactive)
        {
            var filterDefinition = _filterDefinitionBuilder.Where(item => item.Id.Equals(userId) &&
                                                                          item.Status == status);

            return DeleteOneAsync(filterDefinition);
        }
    }
}
