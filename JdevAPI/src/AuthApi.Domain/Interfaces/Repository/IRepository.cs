namespace AuthApi.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
