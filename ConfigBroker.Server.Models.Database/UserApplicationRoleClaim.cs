using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

[PrimaryKey(nameof(Id))]
public class UserApplicationRoleClaim : IEntity
{
    public Guid Id { get; set; }
    
    public Application Application { get; set; }
    
    public User User { get; set; }

    public RoleClaim Claim { get; set; }
}