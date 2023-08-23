namespace Transponder.Api.Services;

using Transponder.Api.Data.Models;
using Transponder.Api.Data.Repositories;

public class TransponderService : ITransponderService
{
    private readonly ITransponderRepositoryFactory _repositoryFactory;
    
    public TransponderService(ITransponderRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }
    
    public Transponder Create(Vehicle vehicle)
    {
        //assuming that vehicle.Year was validated before
        var factory = _repositoryFactory.GetTransponderRepository(int.Parse(vehicle.Year));
        
        return factory.Create(vehicle);
    }

    //TODO: Required by the diagram. What's that for? We already have a vehicle created.
    public void OnVehicleCreated(VehicleEventArgs vehicleEventArgs)
    {
        throw new NotImplementedException();
    }
}
