using BuilderBenchmark.Models;

namespace BuilderBenchmark.Builders;

public sealed class ViaClassesBuilder
{
    public EmptyBuilder GetBuilder()
    {
        var document = new Document();

        return new EmptyBuilder(document);
    }
}

public sealed class EmptyBuilder
{
    private readonly Document _document;

    public EmptyBuilder(Document document)
    {
        _document = document;
    }

    public WithCreatorBuilder CreatedBy(User user)
    {
        _document.States.Add(new DocumentState
        {
            AddedBy = user.Id,
            DocumentStateEnum = DocumentStateEnum.Created,
        });

        return new WithCreatorBuilder(_document);
    }
}

public sealed class WithCreatorBuilder
{
    private readonly Document _document;

    public WithCreatorBuilder(Document document)
    {
        _document = document;
    }

    public WithEventBuilder CreatedViaEvent(Event @event)
    {
        _document.EventId = @event.Id;
        _document.FormId = @event.FormId;
        _document.CreatedAt = @event.CreatedAt;

        return new WithEventBuilder(_document);
    }
}

public sealed class WithEventBuilder
{
    private readonly Document _document;

    public WithEventBuilder(Document document)
    {
        _document = document;
    }

    public WithTypeBuilder WithType(DocumentTypeEnum type)
    {
        _document.Type = type;

        return new WithTypeBuilder(_document);
    }
}

public sealed class WithTypeBuilder
{
    private readonly Document _document;

    public WithTypeBuilder(Document document)
    {
        _document = document;
    }

    public ReadyBuilder IssuedAtServiceCenter(ServiceCenter serviceCenter)
    {
        _document.ServiceCenterCode = serviceCenter.Code;

        return new ReadyBuilder(_document);
    }
}

public sealed class ReadyBuilder
{
    private readonly Document _document;

    public ReadyBuilder(Document document)
    {
        _document = document;
    }

    public Document Build()
    {
        return _document;
    }
}