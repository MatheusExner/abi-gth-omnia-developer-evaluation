using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated Sales will have valid:
    /// - BranchId (random guid)
    /// - CustomerId (random guid)
    /// - SaleItemsIds (list of random guid)
    /// </summary>
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(u => u.BranchId, f => f.Random.Guid())
        .RuleFor(u => u.CustomerId, f =>f.Random.Guid())
        .RuleFor(u => u.SaleItemsIds, f => f.Make(5, () => f.Random.Guid()));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated Sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }
}
