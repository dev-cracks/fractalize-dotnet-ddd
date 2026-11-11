using Fractalize.Ddd.SharedKernel.Audit;
using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test.Audit;

public class AuditStubsTest
{
    [Fact]
    [UnitTest]
    public void ClockStampStub_GetCurrentTime_ReturnsCurrentUtcTime()
    {
        var before = DateTimeOffset.UtcNow;

        var now = new ClockStampStub().GetCurrentTime();

        Assert.InRange(now, before, DateTimeOffset.UtcNow);
        Assert.Equal(TimeSpan.Zero, now.Offset);
    }

    [Fact]
    [UnitTest]
    public async Task AuditRepositoryStub_SaveEventAsync_CompletesWithoutStoring()
    {
        var auditedEvent = new AuditedEvent { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow };

        var task = new AuditRepositoryStub().SaveEventAsync(auditedEvent);
        await task;

        Assert.True(task.IsCompletedSuccessfully);
    }
}
