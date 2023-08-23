namespace Transponder.Api.Data.Models;

using System.ComponentModel.DataAnnotations;

public class VehicleDto
{
    //TODO: Better validation
    [Required] public string Make { get; init; } = null!;
    [Required] public string Model { get; init; } = null!;
    [Required] public string Year { get; init; } = null!;
}
