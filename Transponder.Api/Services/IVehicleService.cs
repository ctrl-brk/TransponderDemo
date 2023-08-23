namespace Transponder.Api.Services;

using Transponder.Api.Data;
using Transponder.Api.Data.Models;

public interface IVehicleService
{
    event EventHandler<VehicleEventArgs> VehicleCreated;

    Vehicle Create(Vehicle vehicle);    
}
