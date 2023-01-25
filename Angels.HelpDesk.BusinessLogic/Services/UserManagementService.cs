using Angels.HelpDesk.Application.Commons;
using Angels.HelpDesk.Application.Dtos.UserManagement;
using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Angels.HelpDesk.Domain.Enums;
using Angels.HelpDesk.Domain.Interfaces.Models.AuthService;
using Angels.HelpDesk.Domain.Models.UserManagement;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Angels.HelpDesk.BusinessLogic.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly ILogger<UserManagementService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManagementService(
            ILogger<UserManagementService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<DatatableData> GetAllUsersForTheDatatable()
        {
            _logger.LogDebugInMethod(nameof(GetAllUsersForTheDatatable));

            var userList = await _userRepository.FindAllByStatus();
            var basicUserList = _mapper.Map<List<BasicUserInfo>>(userList);

            List<List<string>> userData = new();

            foreach (var basicUser in basicUserList)
            {
                userData.Add(new()
                {
                    basicUser.Name,
                    basicUser.Surname,
                    basicUser.Email,
                    basicUser.Identification.Value,
                    basicUser.PhoneNumber,
                    basicUser.Role.Text,
                    $"EditButton: {basicUser.Id}",
                    $"DeleteButton: {basicUser.Id}"
                });
            }

            return new()
            {
                SEcho = 1,
                ITotalRecords = basicUserList.Count,
                ITotalDisplayRecords = basicUserList.Count,
                AaData = userData
            };
        }

        public async Task<BasicUserInfo> GetBasicUserInformation(string userId)
        {
            _logger.LogDebugInMethod(nameof(GetBasicUserInformation));

            var userList = await _userRepository.FindOneByIdAndStatus(userId);

            if (userList is null)
                throw new InvalidOperationException("El usuario no se encuentra activo en el sistema.");

            return _mapper.Map<BasicUserInfo>(userList);
        }
        public async Task ChangeStatusForTheUser(StatusChange statusChange)
        {
            _logger.LogDebugInMethod(nameof(ChangeStatusForTheUser));

            await _userRepository.ChangeStatusByIdAndStatus(
                userId: statusChange.UserId,
                status: (Status)statusChange.Status);
        }
        public async Task UpdateUser(UserInfoToUpdate basicUser)
        {
            _logger.LogDebugInMethod(nameof(UpdateUser));

            var userModelDb = _mapper.Map<User>(basicUser);
            await _userRepository.UpdateUserData(userModelDb);
        }
        public async Task DeleteUser(string userId)
        {
            _logger.LogDebugInMethod(nameof(DeleteUser));
            await _userRepository.DeleteUserByIdAndStatus(userId);
        }
    }
}
