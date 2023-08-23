namespace Transponder.Api.Data.Repositories;

public interface ITransponderRepositoryFactory
{
    ITransponderRepository GetTransponderRepository(int year);
}