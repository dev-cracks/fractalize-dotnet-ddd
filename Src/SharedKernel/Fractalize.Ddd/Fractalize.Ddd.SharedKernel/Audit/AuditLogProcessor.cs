namespace Fractalize.Ddd.SharedKernel.Audit;

public class AuditLogProcessor(
    IClockStamp clockStamp,
    IAuditRepository auditRepository) : IAuditLogProcessor
{
    public async Task ProcessEventAsync(Guid id, Guid userId)
    {
        var auditedEvent = new AuditedEvent()
        {
            Id = id,
            UserId = userId,
            CreatedAt = clockStamp.GetCurrentTime(),
        };

        await auditRepository.SaveEventAsync(auditedEvent);
    }
}

public record AuditedEvent
{
    public required Guid Id { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }

    public required Guid UserId { get; init; }
}
