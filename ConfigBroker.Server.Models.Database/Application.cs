using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

[PrimaryKey(nameof(Id))]
[Index(nameof(Name))]
public class Application : INamedEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public User CreatedBy { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public DateTime UpdatedOn { get; set; }
    
    public List<ConfigItem> ConfigItems { get; set; }
    
    public List<Snapshot> Snapshots { get; set; }
}