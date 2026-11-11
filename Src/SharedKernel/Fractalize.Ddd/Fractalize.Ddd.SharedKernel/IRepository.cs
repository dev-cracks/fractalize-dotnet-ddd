namespace Fractalize.Ddd.SharedKernel;

public interface IRepository<TEntity, Tid> where TEntity : AggregateRootBase<Tid>
{
}
