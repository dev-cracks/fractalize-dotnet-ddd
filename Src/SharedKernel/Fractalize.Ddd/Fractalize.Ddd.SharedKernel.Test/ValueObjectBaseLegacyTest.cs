namespace Fractalize.Ddd.SharedKernel.Test;

public class ValueObjectBaseLegacyTest
{
    [Fact]
    public void ValueObjectBaseLegacy_WithSameValues_ShouldBeEquals()
    {
        var money1 = new MoneyStub()
        {
            Amount = 25,
            Currency = "USD"
        };

        var money2 = new MoneyStub()
        {
            Amount = 25,
            Currency = "USD"
        };

        var equals = money1.CompareTo(money2);

        Assert.Equal(0, equals);
    }

    [Fact]
    public void ValueObjectBaseLegacy_WithSameValues_ShouldBeDifferent()
    {
        var money1 = new MoneyStub()
        {
            Amount = 30,
            Currency = "USD"
        };

        var money2 = new MoneyStub()
        {
            Amount = 25,
            Currency = "USD"
        };

        var equals = money1.CompareTo(money2);

        Assert.NotEqual(0, equals);
    }
}

internal class MoneyStub : ValueObjectLegacyBase
{
    public required string Currency { get; set; }
    public required decimal Amount { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Amount;
    }
}
