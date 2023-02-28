namespace inferback.Domain.ViewEntities;

public class ReportView {
    public int id { get; set; }

    public string? name { get; set; }
    
    public string? path { get; set; }
    
    public int projectId { get; set; }
}