namespace Transponder.Api.Services;

using Transponder.Api.Data;
using Transponder.Api.Data.Models;

public class VehicleEventArgs : EventArgs
{
    public Vehicle Vehicle { get; }

    public VehicleEventArgs(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }    
}
