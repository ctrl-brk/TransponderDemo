namespace Transponder.Api.Data.Repositories;

using Transponder.Api.Data.Models;

public interface ITransponderRepository
{
    Transponder Create(Vehicle vehicle);
}
