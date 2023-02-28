using System.Text.Json.Serialization;

namespace inferback.Domain.Entity;

public class Description {
    public int id { get; set; }
    
    public string? name { get; set; }

    [JsonPropertyName("bug_type")] public string bug_type { get; set; }

    [JsonPropertyName("qualifier")] public string qualifier { get; set; }

    [JsonPropertyName("severity")] public string severity { get; set; }

    [JsonPropertyName("line")] public int line { get; set; }

    [JsonPropertyName("column")] public int column { get; set; }

    [JsonPropertyName("file")] public string file { get; set; }

    public int reportId { get; set; }

    public Report report { get; set; }
}
