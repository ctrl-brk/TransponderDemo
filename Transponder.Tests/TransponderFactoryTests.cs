using Xunit;

namespace Transponder.Tests;

using Transponder.Api.Data.Repositories;

public sealed class TransponderFactoryTests
{
    [Theory]
    [InlineData(1990, typeof(ClassicTransponderRepository))]
    [InlineData(2020, typeof(ModernTransponderRepository))]
    public void CreateTransponderRepository_ReturnsCorrectTypeBasedOnYear(int year, System.Type expectedType)
    {
        var result = new TransponderRepositoryFactory().GetTransponderRepository(year);

        Assert.IsType(expectedType, result);
    }
}
