namespace Fractalize.Ddd.SharedKernel.Test;

public class ValueObjectBaseTest
{
    [Fact]
    public void RecordEqualityComparer_1()
    {
        var valueObject1 = new AddressStub("velazquez", 3, new ClassStub
        {
            Street = "velazquez",
            Number = 3
        });

        var valueObject2 = new AddressStub("velazquez", 3, new ClassStub
        {
            Street = "velazquez",
            Number = 3
        });

        Assert.False(valueObject1 == valueObject2);
    }

    [Fact]
    public void RecordEqualityComparer_2()
    {
        var objReference = new ClassStub
        {
            Street = "velazquez",
            Number = 3
        };


        var valueObject1 = new AddressStub("velazquez", 3, objReference);

        var valueObject2 = new AddressStub("velazquez", 3, objReference);

        Assert.True(valueObject1 == valueObject2);
    }

    [Fact]
    public void RecordEqualityComparer_3()
    {
        var valueObject1 = new ClassStub()
        {
            Street = "velazquez",
            Number = 3
        };

        var valueObject2 = new ClassStub()
        {
            Street = "velazquez",
            Number = 3
        };

        Assert.False(valueObject1 == valueObject2);
    }

    [Fact]
    public void RecordEqualityComparer_4()
    {
        var valueObject1 = new AddressStub2("velazquez", 3, new NameStub("Daniel", "Yepes"));

        var valueObject2 = new AddressStub2("velazquez", 3, new NameStub("Daniel", "Yepes"));

        Assert.True(valueObject1 == valueObject2);
    }
}

internal record AddressStub(string street, int number, ClassStub tmpClass) : ValueObjectBase;

internal record AddressStub2(string street, int number, NameStub tmpStub) : ValueObjectBase;

internal class ClassStub()
{
    public string Street { get; set; }
    public int Number { get; set; }
}

internal record NameStub(string fisrtName, string sureName);
