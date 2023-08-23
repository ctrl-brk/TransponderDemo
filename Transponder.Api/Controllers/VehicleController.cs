namespace Transponder.Api.Controllers;

using Transponder.Api.Data.Models;
using Transponder.Api.Services;

[ApiController]
[Route("[controller]")]
public class VehicleController : ApiController
{
    private readonly ILogger<VehicleController> _logger;
    private readonly IVehicleService _vehicleService;
    private readonly ITransponderService _transponderService;

    public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService, ITransponderService transponderService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
        _transponderService = transponderService ?? throw new ArgumentNullException(nameof(transponderService));
        
        _vehicleService.VehicleCreated += VehicleServiceOnVehicleCreated;
    }

    // should be Task<ActionResult<Vehicle>> IRL, but following the diagram here
    [HttpPost]
    public Vehicle Create(VehicleDto vehicleDto)
    {
        _logger.LogInformation("Create vehicle request received {@VehicleDto}", vehicleDto);
        
        var newVehicle = _vehicleService.Create(new Vehicle(vehicleDto));

        // should contain a URI to get the created object, but we're not implementing this yet
        Response.StatusCode = StatusCodes.Status201Created;
        return newVehicle;
    }
    
    private void VehicleServiceOnVehicleCreated(object? sender, VehicleEventArgs e)
    {
        _logger.LogInformation("Vehicle {VehicleId} was successfully created", e.Vehicle.Id);
        var transponder = _transponderService.Create(e.Vehicle);
        _logger.LogInformation("Transponder {TransponderId} for vehicle {VehicleId} was successfully created", transponder.Id, e.Vehicle.Id);
    }
}
