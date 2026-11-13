using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test;

public class AggregateRootBaseTest
{
    [Fact]
    [UnitTest]
    public void AddDomainEvent_WithAnEvent_ExposesItInDomainEvents()
    {
        // Arrange
        var aggregate = new TestAggregate { Id = Guid.NewGuid() };
        var domainEvent = new TestDomainEvent { Name = "created", Date = DateTimeOffset.UtcNow };

        // Act
        aggregate.AddDomainEvent(domainEvent);

        // Assert
        Assert.Same(domainEvent, Assert.Single(aggregate.DomainEvents));
    }

    [Fact]
    [UnitTest]
    public void ClearDomainEvents_WithPendingEvents_RemovesThemAll()
    {
        var aggregate = new TestAggregate { Id = Guid.NewGuid() };
        aggregate.AddDomainEvent(new TestDomainEvent { Name = "created", Date = DateTimeOffset.UtcNow });
        aggregate.AddDomainEvent(new TestDomainEvent { Name = "renamed", Date = DateTimeOffset.UtcNow });

        aggregate.ClearDomainEvents();

        Assert.Empty(aggregate.DomainEvents);
    }

    [Fact]
    [UnitTest]
    public void ObsoleteClearDomainEvents_WithAnEvent_ClearsInsteadOfAdding()
    {
        var aggregate = new TestAggregate { Id = Guid.NewGuid() };
        var domainEvent = new TestDomainEvent { Name = "created", Date = DateTimeOffset.UtcNow };
        aggregate.AddDomainEvent(domainEvent);

#pragma warning disable CS0618 // Covers the obsolete overload on purpose.
        aggregate.ClearDomainEvents(domainEvent);
#pragma warning restore CS0618

        Assert.Empty(aggregate.DomainEvents);
    }

    [Fact]
    [UnitTest]
    public void DomainEvents_OnANewAggregate_IsEmpty()
    {
        var aggregate = new TestAggregate { Id = Guid.NewGuid() };

        Assert.Empty(aggregate.DomainEvents);
    }

    private sealed class TestAggregate : AggregateRootBase<Guid>;

    private sealed class TestDomainEvent : DomainEventBase
    {
        public override required string Name { get; set; }

        public override required DateTimeOffset Date { get; set; }
    }
}
