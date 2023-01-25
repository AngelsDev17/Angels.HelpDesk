using Angels.HelpDesk.Domain.Models.DomainLists;

namespace Angels.HelpDesk.Persistence.Test.InitialProjectSettings.DomainLists
{
    public static class RoleMockData
    {
        public static List<Role> Roles => new()
        {
            new() { Id = "A", Text = "Administrador" },
            new() { Id = "U", Text = "Usuario" }
        };
    }
}
