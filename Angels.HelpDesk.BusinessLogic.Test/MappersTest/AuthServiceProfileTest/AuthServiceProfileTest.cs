using Angels.HelpDesk.BusinessLogic.Mappers;
using AutoMapper;
using Xunit;

namespace Angels.HelpDesk.BusinessLogic.Test.MappersTest.AuthServiceProfileTest
{
    public class AuthServiceProfileTest
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;

        public AuthServiceProfileTest()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuthServiceProfile>();
                cfg.AddProfile<DomainListProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }


        [Fact]
        public void ShouldBe_ValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
    }
}
