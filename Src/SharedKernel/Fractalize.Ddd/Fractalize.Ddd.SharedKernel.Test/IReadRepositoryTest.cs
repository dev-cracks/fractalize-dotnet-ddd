using Moq;
using System.Linq.Expressions;

namespace Fractalize.Ddd.SharedKernel.Test;

public class IReadRepositoryTest
{
    [Fact]
    public async Task WhereAsync_WithExpressionProvided_ShouldReturnFilteredEntities()
    {
        //Arrage
        var mockPersons = new List<PersonStub>()
        {
            new() { Id = Guid.NewGuid(), Name = "Charles", IsActive = true },
            new() { Id = Guid.NewGuid(), Name = "Ana", IsActive = false },
            new() { Id = Guid.NewGuid(), Name = "Martha", IsActive = true },
        };

        var mockRepo = new Mock<IReadRepository<PersonStub, Guid>>();
        mockRepo.Setup(repo => repo.WhereAsync(It.IsAny<Expression<Func<PersonStub, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([.. mockPersons.Where(x=> x.IsActive)]);

        //Act
        var filteredPersons = await mockRepo.Object.WhereAsync(x => x.IsActive);

        //Asert
        Assert.NotNull(filteredPersons);
        Assert.Equal(2, filteredPersons.Count);
        Assert.Equal(mockPersons[0].Name, filteredPersons.First().Name);
        mockRepo.Verify(s=> s.WhereAsync(It.IsAny<Expression<Func<PersonStub, bool>>>(), default), Times.Once);
    }

}

internal class PersonStub : EntityBase<Guid>
{
    public required string Name { get; set; }

    public bool IsActive { get; set; }
}
