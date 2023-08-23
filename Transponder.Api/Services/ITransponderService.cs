namespace Transponder.Api.Services;

using Transponder.Api.Data.Models;

public interface ITransponderService
{
    Transponder Create(Vehicle vehicle);
    
    //TODO: Required by the diagram. What's that for? We already have a vehicle created.
    void OnVehicleCreated(VehicleEventArgs vehicleEventArgs);
}
