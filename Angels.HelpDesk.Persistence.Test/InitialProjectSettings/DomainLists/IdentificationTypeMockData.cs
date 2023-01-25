using Angels.HelpDesk.Domain.Models.DomainLists;

namespace Angels.HelpDesk.Persistence.Test.InitialProjectSettings.DomainLists
{
    public static class IdentificationTypeMockData
    {
        public static List<IdentificationType> IdentificationTypes => new()
        {
            new() { Id = "CC", Text = "Cédula" },
            new() { Id = "TI", Text = "Tarjeta de identidad" },
            new() { Id = "CE", Text = "Cédula de extranjeria" },
            new() { Id = "PS", Text = "Pasaporte" }
        };
    }
}
