namespace Fractalize.Ddd.SharedKernel;

public abstract class AggregateRootBase<TId> : EntityBase<TId>
{
    private readonly List<DomainEventBase> _domainEvents = [];

    public IReadOnlyCollection<DomainEventBase> DomainEvents => _domainEvents;

    public void AddDomainEvent(DomainEventBase domainEvent) =>
        _domainEvents.Add(domainEvent);

    /// <summary>
    /// Removes every pending domain event, typically after they have been dispatched.
    /// </summary>
    public void ClearDomainEvents() =>
        _domainEvents.Clear();

    /// <summary>
    /// Removes every pending domain event. The argument is ignored.
    /// </summary>
    [Obsolete("Use ClearDomainEvents() instead. This overload used to add the event instead of clearing the list.")]
    public void ClearDomainEvents(DomainEventBase _) =>
        ClearDomainEvents();
}
