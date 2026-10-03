namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface INamedEntity : IEntity
{
    string Name { get; set; }
}