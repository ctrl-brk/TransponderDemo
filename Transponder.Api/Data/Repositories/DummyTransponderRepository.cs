namespace Transponder.Api.Data.Repositories;

using Transponder.Api.Data.Models;

/// <remarks>
/// This one in not on the diagram but since both transponder repositories "should do the same thing",
/// they can inherit from the same parent.
/// Note that the storage is still unique for each repository. This can be changed to a shared one if needed.
///
/// In general we could create some generic repository and use it for vehicles and transponders in this sample project.
/// </remarks>
public class DummyTransponderRepository : ITransponderRepository
{
    //TODO: concurrency in case of singleton
    protected readonly List<Transponder> Transponders = new();

    /// <summary>Adds a new transponder to the repository</summary>
    /// <param name="vehicle">Vehicle to be used with this transponder</param>
    /// <returns>Newly created Transponder object with Id populated</returns>
    public virtual Transponder Create(Vehicle vehicle)
    {
        var transponder = new Transponder { Id = NewId(), VehicleId = vehicle.Id };

        Transponders.Add(transponder);
        
        return transponder;
    }

    protected virtual long NewId()
    {
        return Transponders.Count + 1;
    }    
}
