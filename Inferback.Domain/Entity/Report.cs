namespace Inferback.Domain.Entity;

public class Report {
    public int id { get; set; }

    public string? name { get; set; }

    public DateTime createdAt { get; set; } = DateTime.Now;

    public int bugsCount { get; set; }
}