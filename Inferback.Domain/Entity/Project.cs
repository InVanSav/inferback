namespace Inferback.Domain.Entity;

public class Project {
    public int id { get; set; }

    public string? name { get; set; }

    public string? path { get; set; }

    public DateTime createdAt { get; set; } = DateTime.Now;
    
    public List<Report> reports { get; set; }
}