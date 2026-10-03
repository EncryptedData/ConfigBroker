using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

[PrimaryKey(nameof(Id))]
[Index(nameof(Name))]
public class Snapshot : INamedEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public User CreatedBy { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public Application Application { get; set; }
    
    public List<ConfigItem> ConfigItems { get; set; }
}