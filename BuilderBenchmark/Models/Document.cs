namespace BuilderBenchmark.Models;

public sealed class Document
{
    public DateTime CreatedAt { get; set; }

    public Guid EventId { get; set; }

    public Guid FormId { get; set; }

    public DocumentTypeEnum Type { get; set; }

    public List<DocumentState> States { get; set; } = new();

    public string ServiceCenterCode { get; set; }
}