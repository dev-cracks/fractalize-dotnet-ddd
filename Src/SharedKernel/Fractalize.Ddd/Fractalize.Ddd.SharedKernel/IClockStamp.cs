namespace Fractalize.Ddd.SharedKernel;

public interface IClockStamp
{
    DateTimeOffset GetCurrentTime();
}
