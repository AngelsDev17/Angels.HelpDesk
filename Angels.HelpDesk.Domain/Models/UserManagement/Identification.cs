using Angels.HelpDesk.Domain.Commons;

namespace Angels.HelpDesk.Domain.Models.UserManagement
{
    public class Identification
    {
        public string Value { get; set; }
        public ReferencedValue IdentificationType { get; set; }
    }
}
