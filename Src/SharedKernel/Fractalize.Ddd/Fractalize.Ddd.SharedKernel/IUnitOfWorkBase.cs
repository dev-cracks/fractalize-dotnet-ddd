namespace Fractalize.Ddd.SharedKernel;

public interface IUnitOfWorkBase : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
