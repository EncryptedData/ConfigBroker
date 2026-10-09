namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IUnitOfWork : IAsyncDisposable
{
    IApplicationRepository ApplicationRepository { get; }
    
    IConfigItemRepository ConfigItemRepository { get; }
    
    ISnapshotRepository SnapshotRepository { get; }
    
    IUserRepository UserRepository { get; }

    Task CommitAsync(CancellationToken cancellationToken = default);
}