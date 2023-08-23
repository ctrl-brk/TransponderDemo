namespace Transponder.Api.Data.Repositories;

public class TransponderRepositoryFactory : ITransponderRepositoryFactory
{
    private ClassicTransponderRepository? _classicRepository;
    private ModernTransponderRepository? _modernRepository;
    
    public ITransponderRepository GetTransponderRepository(int year)
    {
        //DI could be used here, but that will create both instances ever time. Performance/memory/garbage collection.
        //Although, that approach will be easier to unit test.
        //In dotnet 8 there will be named DI. Would be helpful here.

        if (year <= DateTime.Now.Year - 25)
        {
            return _classicRepository ??= new ClassicTransponderRepository();
        }

        return _modernRepository ??= new ModernTransponderRepository();
    }
}
