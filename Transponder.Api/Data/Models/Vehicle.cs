namespace Transponder.Api.Data.Models;

public class Vehicle
{
    public long Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }

    public Vehicle(VehicleDto vehicleDto)
    {
        // some automapping solutions could be employed here
        Make = vehicleDto.Make;
        Model = vehicleDto.Model;
        Year = vehicleDto.Year;
    }
}
