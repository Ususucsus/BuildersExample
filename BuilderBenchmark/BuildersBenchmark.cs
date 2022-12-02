using BenchmarkDotNet.Attributes;
using BuilderBenchmark.Builders;
using BuilderBenchmark.Models;

namespace BuilderBenchmark;

[MemoryDiagnoser]
public class BuildersBenchmark
{
    private static User _user = new() { Id = Guid.NewGuid() };
    private static ServiceCenter _serviceCenter = new() { Code = "0800" };
    private static Event _event = new() { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow, FormId = Guid.NewGuid() };
    private static DocumentTypeEnum _type = DocumentTypeEnum.Statement;

    [Benchmark(Baseline = true)]
    public bool CreateDocumentViaInterfacesBuilder()
    {
        for (var i = 0; i < 1_000_000; i++)
        {
            var document = ViaInterfacesBuilder.GetBuilder()
                .CreatedBy(_user)
                .CreatedViaEvent(_event)
                .WithType(_type)
                .IssuedAtServiceCenter(_serviceCenter)
                .Build();
        }

        return true;
    }

    [Benchmark]
    public bool CreateDocumentViaClassesBuilder()
    {
        for (var i = 0; i < 1_000_000; i++)
        {
            var document = new ViaClassesBuilder().GetBuilder()
                .CreatedBy(_user)
                .CreatedViaEvent(_event)
                .WithType(_type)
                .IssuedAtServiceCenter(_serviceCenter)
                .Build();
        }

        return true;
    }
}