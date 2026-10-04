using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

[PrimaryKey(nameof(Id))]
[Index(nameof(Name))]
public class Group : INamedEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public List<UserGroupRoleClaim> UserClaims { get; set; }
    
    public List<Application> Applications { get; set; }
}