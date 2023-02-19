namespace Inferback.Domain.ViewEntities; 

public class ReportView {
    public int id { get; set; }
    
    public string? name { get; set; }
    
    public int bugsCount { get; set; }

    public int projectId { get; set; }
}