using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Angels.HelpDesk.Application.Commons
{
    public class ReferencedValue
    {
        [Required]
        public string Id { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Text { get; set; } = null;
    }
}
