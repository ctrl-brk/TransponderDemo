namespace Transponder.Api.Data.Repositories;

using Transponder.Api.Data.Models;

public interface IVehicleRepository
{
    Vehicle Create(Vehicle vehicle);
}
