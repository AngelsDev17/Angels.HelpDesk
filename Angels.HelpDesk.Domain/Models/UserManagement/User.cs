using Angels.HelpDesk.Domain.Commons;
using Angels.HelpDesk.Domain.Enums;

namespace Angels.HelpDesk.Domain.Models.UserManagement
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Identification Identification { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ReferencedValue Role { get; set; }
        public Status Status { get; set; }
    }
}
