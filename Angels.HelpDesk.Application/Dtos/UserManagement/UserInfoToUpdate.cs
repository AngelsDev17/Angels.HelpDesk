using Angels.HelpDesk.Application.Commons;

namespace Angels.HelpDesk.Application.Dtos.UserManagement
{
    public class UserInfoToUpdate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Identification Identification { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ReferencedValue Role { get; set; }
    }
}
