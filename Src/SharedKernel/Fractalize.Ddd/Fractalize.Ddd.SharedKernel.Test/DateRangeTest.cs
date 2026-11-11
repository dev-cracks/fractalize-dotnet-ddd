using Xunit.Categories;

namespace Fractalize.Ddd.SharedKernel.Test;

public class DateRangeTest
{
    [Fact]
    [UnitTest]
    public void Constructor_WithStartDateHigherThanEnd_ThrowsArgumentOutOfRangeException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new DateRange(startDate: DateTimeOffset.Now.AddDays(1), endDate: DateTimeOffset.Now.AddDays(-1)));
    }

    [Fact]
    [UnitTest]
    public void Constructor_WithNullStartDate_ThrowsArgumentOutOfRangeException()
    {
        // Arrange & Act & Assert
        var startDateDefaultException = Assert.Throws<ArgumentNullException>(() => new DateRange(startDate: default, endDate: DateTimeOffset.Now.AddDays(-1)));
        Assert.Equal("startDate", startDateDefaultException.ParamName);

        var endDateDefaultException = Assert.Throws<ArgumentNullException>(() => new DateRange(startDate: DateTimeOffset.Now.AddDays(-1), endDate: default));
        Assert.Equal("endDate", endDateDefaultException.ParamName);
    }

    [Fact]
    [UnitTest]
    public void DurationInMinutes_WithAValidRange_GetPositiveIntervalInMinutes()
    {
        var startDate = DateTimeOffset.Now;
        var endDate = DateTimeOffset.Now.AddDays(1);

        var expectedIntervalInMinutes = (endDate - startDate).TotalMinutes;

        //Arrage
        var dateRange = new DateRange(startDate, endDate);

        //Act
        var intervalInMinutes = dateRange.DurationInMinutes();

        //Assert
        Assert.Equal(expectedIntervalInMinutes, intervalInMinutes);
    }

    [Fact]
    [UnitTest]
    public void DurationInMinutesRounded_WithAValidRange_GetPositiveIntervalInMinutes()
    {
        var startDate = DateTimeOffset.Now;
        var endDate = DateTimeOffset.Now.AddDays(1);

        var expectedIntervalInMinutes = (int)(endDate - startDate).TotalMinutes;

        //Arrage
        var dateRange = new DateRange(startDate, endDate);

        //Act
        var intervalInMinutes = dateRange.DurationInMinutesRounded();

        //Assert
        Assert.Equal(expectedIntervalInMinutes, intervalInMinutes);
    }

    [Fact]
    [UnitTest]
    public void StartAndEnd_ModifiedByEncapsulation_ShouldNotChange()
    {
        var startDate = DateTimeOffset.Now;
        var endDate = DateTimeOffset.Now.AddDays(1);

        //Arrage
        var dateRange = new DateRange(startDate, endDate);

        //Act
        dateRange.Start.AddDays(100);
        dateRange.End.AddYears(-100);

        //Assert
        Assert.Equal(startDate, dateRange.Start);
        Assert.Equal(endDate, dateRange.End);
    }

    [Fact]
    [UnitTest]
    public void Overlaps_WithARangeThatStartsInside_ReturnsTrue()
    {
        var start = new DateTimeOffset(2026, 1, 1, 10, 0, 0, TimeSpan.Zero);
        var range = new DateRange(start, start.AddHours(2));
        var other = new DateRange(start.AddHours(1), start.AddHours(3));

        Assert.True(range.Overlaps(other));
    }
}
