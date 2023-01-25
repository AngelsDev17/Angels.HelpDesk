using Angels.HelpDesk.Application.Commons;
using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Angels.HelpDesk.Domain.Interfaces.Models.DomainLists;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Angels.HelpDesk.BusinessLogic.Services
{
    public class DomainListService : IDomainListService
    {
        private readonly ILogger<DomainListService> _logger;
        private readonly IIdentificationTypeRepository _identificationTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public DomainListService(
            ILogger<DomainListService> logger,
            IIdentificationTypeRepository identificationTypeRepository,
            ICategoryRepository categoryRepository,
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _identificationTypeRepository = identificationTypeRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }


        public async Task<List<ReferencedValue>> GetIdentificationTypeList()
        {
            _logger.LogDebugInMethod(nameof(GetIdentificationTypeList));

            var identificationTypes = await _identificationTypeRepository.FindAllByStatusAsync();

            return _mapper.Map<List<ReferencedValue>>(identificationTypes);
        }
        public async Task<List<ReferencedValue>> GetCategoryList()
        {
            _logger.LogDebugInMethod(nameof(GetCategoryList));

            var categories = await _categoryRepository.FindAllByStatusAsync();

            return _mapper.Map<List<ReferencedValue>>(categories);
        }
        public async Task<List<ReferencedValue>> GetRoleList()
        {
            _logger.LogDebugInMethod(nameof(GetRoleList));

            var roles = await _roleRepository.FindAllByStatusAsync();

            return _mapper.Map<List<ReferencedValue>>(roles);
        }
    }
}
