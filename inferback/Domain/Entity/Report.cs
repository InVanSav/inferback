namespace inferback.Domain.Entity;

public class Report {
    public int id { get; set; }

    public string? name { get; set; }

    public DateTime createdAt { get; set; } = DateTime.Now;
    
    public int projectId { get; set; }

    public Project project { get; set; }
    
    public List<Description> descriptions { get; set; }
}