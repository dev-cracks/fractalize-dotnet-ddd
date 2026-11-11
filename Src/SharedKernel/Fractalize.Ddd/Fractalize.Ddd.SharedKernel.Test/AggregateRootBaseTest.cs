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
