namespace Fractalize.Ddd.SharedKernel.Audit;

public interface IAuditRepository
{
    Task SaveEventAsync(AuditedEvent auditedEvent);
}
