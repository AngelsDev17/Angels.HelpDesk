using Angels.HelpDesk.Domain.Commons;
using Angels.HelpDesk.Domain.Enums;

namespace Angels.HelpDesk.Domain.Models.AuthService
{
    public class AuthUser : AuditableEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
