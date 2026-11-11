namespace Fractalize.Ddd.SharedKernel.Audit;

public interface IAuditLogProcessor
{
    Task ProcessEventAsync(Guid id, Guid userId);
}
