namespace Transponder.Api.Services;

using Transponder.Api.Data.Models;
using Transponder.Api.Data.Repositories;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    
    // Should events be obsolete in a backend api? Something like Mediator could be a better approach.
    public event EventHandler<VehicleEventArgs>? VehicleCreated;

    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    
    public Vehicle Create(Vehicle vehicle)
    {
        // this should be within some kind of a transaction IRL
        
        var newVehicle = _vehicleRepository.Create(vehicle);
        
        VehicleCreated?.Invoke(this, new VehicleEventArgs(vehicle));
        
        return newVehicle;
    }
}
