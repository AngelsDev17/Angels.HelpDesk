using Angels.HelpDesk.Application.Enums;

namespace Angels.HelpDesk.Application.Dtos.UserManagement
{
    public class StatusChange
    {
        public string UserId { get; set; }
        public Status Status { get; set; }
    }
}
