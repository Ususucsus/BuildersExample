namespace BuilderBenchmark.Models;

public sealed class Event
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid FormId { get; set; }
}