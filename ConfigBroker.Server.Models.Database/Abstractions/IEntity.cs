namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IEntity
{
    Guid Id { get; set; }
}