using Fractalize.Ddd.SharedKernel.Audit;
using Moq;
using Newtonsoft.Json;
using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test.Audit;

public class AuditLogProcessorTest
{
    [Fact]
    [UnitTest]
    public async Task ProcessEventAsync_WithRightConfiguration_CallsGetCurrentTimeAndSaveEventAsync()
    {
        //Arrange
        var IClockStampMock = new Mock<IClockStamp>();
        var IAuditRepositoryMock = new Mock<IAuditRepository>();
        AuditLogProcessor auditLogProcessor = new AuditLogProcessor(IClockStampMock.Object, IAuditRepositoryMock.Object);

        //Act
        await auditLogProcessor.ProcessEventAsync(Guid.NewGuid(), Guid.NewGuid());

        //Assert
        IClockStampMock.Verify(x => x.GetCurrentTime(), Times.Once);
        IAuditRepositoryMock.Verify(x => x.SaveEventAsync(It.IsAny<AuditedEvent>()), Times.Once);
    }

    [Fact]
    [UnitTest]
    public async Task ProcessEventAsync_GettingTimeFromClockStamp_IsUseAsAuditEventCreationTime()
    {
        //Arrange
        var eventTarget = new AuditedEvent()
        {
            Id = Guid.NewGuid(),
            CreatedAt = default,
            UserId = Guid.NewGuid(),
        };
        DateTimeOffset expectedCreationTime = DateTimeOffset.UtcNow;
        var IClockStampMock = new Mock<IClockStamp>();
        IClockStampMock.Setup(x => x.GetCurrentTime()).Returns(expectedCreationTime);

        var IAuditRepositoryMock = new Mock<IAuditRepository>();
        AuditLogProcessor auditLogProcessor = new AuditLogProcessor(IClockStampMock.Object, IAuditRepositoryMock.Object);

        //Act
        await auditLogProcessor.ProcessEventAsync(eventTarget.Id, eventTarget.UserId);

        //Assert
        IClockStampMock.Verify(x => x.GetCurrentTime(), Times.Once);
        IAuditRepositoryMock.Verify(x => x.SaveEventAsync(It.Is<AuditedEvent>(ev => ev.CreatedAt == expectedCreationTime)), Times.Once);
    }

    [Fact]
    [UnitTest]
    public void AuditedEvent_SerializedAndDeserialized_KeepsItsValues()
    {
        //Arrange
        var eventTarget = new AuditedEvent()
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.UtcNow,
        };
        //Act && Assert
        var rawEvent = JsonConvert.SerializeObject(eventTarget);
        var deserializedEvent = JsonConvert.DeserializeObject<AuditedEvent>(rawEvent);
        Assert.NotNull(deserializedEvent);
        Assert.Equal(eventTarget.Id, deserializedEvent.Id);
        Assert.Equal(eventTarget.UserId, deserializedEvent.UserId);
        Assert.Equal(eventTarget.CreatedAt, deserializedEvent.CreatedAt);
    }
}
