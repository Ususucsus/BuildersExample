using BuilderBenchmark.Models;

namespace BuilderBenchmark.Builders;

public sealed class ViaInterfacesBuilder :
    IEmptyBuilder,
    IWithCreatorBuilder,
    IWithEventBuilder,
    IWithTypeBuilder,
    IReadyBuilder
{
    private readonly Document _document = new();

    private ViaInterfacesBuilder()
    {
    }

    public static IEmptyBuilder GetBuilder()
    {
        return new ViaInterfacesBuilder();
    }

    public IWithCreatorBuilder CreatedBy(User user)
    {
        _document.States.Add(new DocumentState
        {
            AddedBy = user.Id,
            DocumentStateEnum = DocumentStateEnum.Created,
        });

        return this;
    }

    public IWithEventBuilder CreatedViaEvent(Event @event)
    {
        _document.EventId = @event.Id;
        _document.FormId = @event.FormId;
        _document.CreatedAt = @event.CreatedAt;

        return this;
    }

    public IWithTypeBuilder WithType(DocumentTypeEnum type)
    {
        _document.Type = type;

        return this;
    }

    public IReadyBuilder IssuedAtServiceCenter(ServiceCenter serviceCenter)
    {
        _document.ServiceCenterCode = serviceCenter.Code;

        return this;
    }

    public Document Build()
    {
        return _document;
    }
}

public interface IEmptyBuilder
{
    IWithCreatorBuilder CreatedBy(User user);
}

public interface IWithCreatorBuilder
{
    IWithEventBuilder CreatedViaEvent(Event @event);
}

public interface IWithEventBuilder
{
    IWithTypeBuilder WithType(DocumentTypeEnum type);
}

public interface IWithTypeBuilder
{
    IReadyBuilder IssuedAtServiceCenter(ServiceCenter serviceCenter);
}

public interface IReadyBuilder
{
    Document Build();
}