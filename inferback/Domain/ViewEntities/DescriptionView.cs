namespace inferback.Domain.ViewEntities;

public class DescriptionView {
    public string bug_type { get; set; }

    public string qualifier { get; set; }

    public string severity { get; set; }

    public int line { get; set; }

    public int column { get; set; }

    public string file { get; set; }

    public int reportId { get; set; }
}