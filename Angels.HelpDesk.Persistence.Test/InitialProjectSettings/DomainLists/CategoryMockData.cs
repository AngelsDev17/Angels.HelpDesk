using Angels.HelpDesk.Domain.Models.DomainLists;

namespace Angels.HelpDesk.Persistence.Test.InitialProjectSettings.DomainLists
{
    public static class CategoryMockData
    {
        public static List<Category> Categories => new()
        {
            new() { Id = "01", Text = "Software" },
            new() { Id = "02", Text = "Hardware" },
            new() { Id = "03", Text = "Incidencia" },
            new() { Id = "04", Text = "Consulta" },
            new() { Id = "05", Text = "Petición de servicio" },
            new() { Id = "06", Text = "Otro" }
        };
    }
}
