namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IUnitOfWork : IAsyncDisposable
{
    IApplicationRepository ApplicationRepository { get; }
    
    IConfigItemRepository ConfigItemRepository { get; }
    
    ISnapshotRepository SnapshotRepository { get; }
    
    IUserRepository UserRepository { get; }
    
    bool IsReadOnly { get; }

    Task CommitAsync(CancellationToken cancellationToken = default);
}