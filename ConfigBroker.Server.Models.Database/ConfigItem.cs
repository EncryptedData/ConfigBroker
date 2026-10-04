using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

[PrimaryKey(nameof(Id))]
public class ConfigItem : IEntity
{
    public Guid Id { get; set; }
    
    public Application Application { get; set; }
    
    /// <summary>
    /// NULL snapshot means latest
    /// </summary>
    public Snapshot? Snapshot { get; set; }
    
    public string Key { get; set; }
    
    public string Value { get; set; }
    
    public ConfigValueSource Source { get; set; }
    
    public User CreatedBy { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public User LastModifiedBy { get; set; }
    
    public DateTime LastModifiedOn { get; set; }
    
    public List<string> Labels { get; set; }
    
    public List<string> Tags { get; set; }
}