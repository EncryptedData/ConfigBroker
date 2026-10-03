using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace ConfigBroker.Server.Models.Database;

public class User : IdentityUser<Guid>, INamedEntity
{
    public string Name { get; set; }
}