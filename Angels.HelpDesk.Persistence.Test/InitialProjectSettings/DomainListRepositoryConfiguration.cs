using Angels.HelpDesk.Domain.Interfaces.Models.DomainLists;
using Angels.HelpDesk.Domain.Models.DomainLists;
using Angels.HelpDesk.Persistence.Repositories.Commons;
using Angels.HelpDesk.Persistence.Repositories.Models.DomainLists;
using Angels.HelpDesk.Persistence.Test.InitialProjectSettings.DomainLists;
using Microsoft.Extensions.Logging;
using Moq;
using Opencity.Utils.MongoDB.ApplicationContext;
using Opencity.Utils.MongoDB.Settings;
using Xunit;

namespace Angels.HelpDesk.Persistence.Test.InitialProjectSettings
{
    public class DomainListRepositoryConfiguration
    {
        private readonly IIdentificationTypeRepository _identificationTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRoleRepository _roleRepository;

        public DomainListRepositoryConfiguration()
        {
            var dbSettings = new DbSettings
            {
                DatabaseName = "HelpDeskDb",
                ConnectionString = "mongodb://localhost:27017/",
            };

            var applicationDbContext = new ApplicationDbContext(dbSettings);

            _identificationTypeRepository = new IdentificationTypeRepository(applicationDbContext, Mock.Of<ILogger<DomainList<IdentificationType>>>());
            _categoryRepository = new CategoryRepository(applicationDbContext, Mock.Of<ILogger<DomainList<Category>>>());
            _roleRepository = new RoleRepository(applicationDbContext, Mock.Of<ILogger<DomainList<Role>>>());
        }


        [Fact]
        public async Task DeleteAndInsertIdentificationType()
        {
            var allModels = await _identificationTypeRepository.FindAllAsync();

            foreach (var model in allModels)
                await _identificationTypeRepository.DeleteOneAsync(model.Id);

            await _identificationTypeRepository.InsertManyAsync(IdentificationTypeMockData.IdentificationTypes);
        }

        [Fact]
        public async Task DeleteAndInsertCategory()
        {
            var allModels = await _categoryRepository.FindAllAsync();

            foreach (var model in allModels)
                await _categoryRepository.DeleteOneAsync(model.Id);

            await _categoryRepository.InsertManyAsync(CategoryMockData.Categories);
        }

        [Fact]
        public async Task DeleteAndInsertRole()
        {
            var allModels = await _roleRepository.FindAllAsync();

            foreach (var model in allModels)
                await _roleRepository.DeleteOneAsync(model.Id);

            await _roleRepository.InsertManyAsync(RoleMockData.Roles);
        }
    }
}
