using ConfigBroker.Server.Models.Database.Abstractions;

namespace ConfigBroker.Server.Models.Database.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ConfigBrokerDbContext _context;

    public UnitOfWork(ConfigBrokerDbContext context)
    {
        _context = context;
        ApplicationRepository = new ApplicationRepository(_context);
        ConfigItemRepository = new ConfigItemRepository(_context);
        SnapshotRepository = new SnapshotRepository(_context);
        UserRepository = new UserRepository(_context);
    }
    
    public IApplicationRepository ApplicationRepository { get; }
    
    public IConfigItemRepository ConfigItemRepository { get; }
    
    public ISnapshotRepository SnapshotRepository { get; }
    
    public IUserRepository UserRepository { get; }
    
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}