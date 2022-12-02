namespace BuilderBenchmark.Models;

public sealed class DocumentState
{
    public DocumentStateEnum DocumentStateEnum { get; set; }

    public Guid AddedBy { get; set; }
}