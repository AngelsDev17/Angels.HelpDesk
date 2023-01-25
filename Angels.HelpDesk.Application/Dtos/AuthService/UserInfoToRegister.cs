using Angels.HelpDesk.Application.Commons;

namespace Angels.HelpDesk.Application.Dtos.AuthService
{
    public class UserInfoToRegister
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Identification Identification { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public ReferencedValue Role { get; set; }
    }
}
