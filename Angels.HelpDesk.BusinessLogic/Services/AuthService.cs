using Angels.HelpDesk.Application.Constants;
using Angels.HelpDesk.Application.Dtos.AuthService;
using Angels.HelpDesk.Application.Dtos.UserManagement;
using Angels.HelpDesk.Application.Interfaces;
using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Angels.HelpDesk.Domain.Interfaces.Models.AuthService;
using Angels.HelpDesk.Domain.Models.UserManagement;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ModelDb = Angels.HelpDesk.Domain.Models.AuthService;

namespace Angels.HelpDesk.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IAuthUserRepository _authUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(
            ILogger<AuthService> logger,
            IAuthUserRepository authUserRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _authUserRepository = authUserRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<string> SignInUser(AuthUser authUser)
        {
            _logger.LogDebugInMethod(nameof(SignInUser));

            var existingUser = await _authUserRepository.FindOneByEmailAndStatus(authUser.Email);

            if (existingUser is null || !BCrypt.Net.BCrypt.Verify(authUser.Password, existingUser.Password))
                throw new InvalidDataException("Las credenciales son incorrectas.");

            var userModelDb = await _userRepository.FindOneByEmailAndStatus(authUser.Email);

            var basicUserInfo = _mapper.Map<BasicUserInfo>(userModelDb);

            return await ConfigureBearerToken(basicUserInfo);
        }
        public async Task<string> RegisterUser(UserInfoToRegister userInfoToRegister)
        {
            _logger.LogDebugInMethod(nameof(RegisterUser));

            var existingUser = await _userRepository.CountByEmailOrIdentification(
                email: userInfoToRegister.Email,
                identification: userInfoToRegister.Identification.Value);

            if (existingUser != 0)
                throw new InvalidOperationException("Este usuario ya se encuentra registrado en el sistema");

            var userAuthDb = new ModelDb.AuthUser()
            {
                Email = userInfoToRegister.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userInfoToRegister.Password)
            };

            var ids = await Task.WhenAll(
                _userRepository.InsertOneAsync(_mapper.Map<User>(userInfoToRegister)),
                _authUserRepository.InsertOneAsync(userAuthDb));

            return await ConfigureBearerToken(
                _mapper.Map<BasicUserInfo>(userInfoToRegister), ids[0]);
        }

        public Task<string> ConfigureBearerToken(BasicUserInfo basicUserInfo, string id = null)
        {
            _logger.LogDebugInMethod(nameof(ConfigureBearerToken));

            ClaimsIdentity claims = new();
            JwtSecurityTokenHandler tokenHandler = new();

            claims.AddClaim(new("sub", id is null ? basicUserInfo.Id : id));
            claims.AddClaim(new("name", basicUserInfo.Name));
            claims.AddClaim(new("surname", basicUserInfo.Surname));
            claims.AddClaim(new("id", basicUserInfo.Identification.Value));
            claims.AddClaim(new("idt", basicUserInfo.Identification.IdentificationType.Id));
            claims.AddClaim(new("email", basicUserInfo.Email));
            claims.AddClaim(new("role", basicUserInfo.Role.Text));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new(
                    new SymmetricSecurityKey(EnvironmentVariables.SECRET_KEY),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(tokenHandler.WriteToken(createdToken));
        }
    }
}
