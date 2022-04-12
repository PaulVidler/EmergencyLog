namespace EmergencyLog.Domain.Entities.Interfaces;

public interface IEmergencyContact
{
    public Client Client { get; set; }
    RelationshipType RelationshipType { get; set; }
}