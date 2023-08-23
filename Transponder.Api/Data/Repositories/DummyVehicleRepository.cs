namespace Transponder.Api.Data.Repositories;

using Transponder.Api.Data.Models;

public class DummyVehicleRepository : IVehicleRepository
{
    private readonly List<Vehicle> _vehicles = new();

    /// <summary>Adds a new vehicle to the repository</summary>
    /// <param name="vehicle"></param>
    /// <returns>Newly created Vehicle object with Id populated</returns>
    /// <remarks>Such operations are mostly async IRL, but following the requirements here</remarks>
    public Vehicle Create(Vehicle vehicle)
    {
        vehicle.Id = NewId();
        _vehicles.Add(vehicle);
        
        return vehicle;
    }

    private long NewId()
    {
        return _vehicles.Count + 1;
    }    
}
