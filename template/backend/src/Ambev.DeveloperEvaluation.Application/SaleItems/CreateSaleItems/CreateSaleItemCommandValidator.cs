using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItems;

/// <summary>
/// Validator for CreateSaleItemCommand that defines validation rules for user creation command.
/// </summary>
public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Requireds
    /// - Quantity: Must be bigger then 0
    /// - UnitPrice: Must be bigger then 0
    /// </remarks>
    public CreateSaleItemCommandValidator()
    {
        RuleFor(Sale => Sale.ProductId).NotEmpty();
        RuleFor(Sale => Sale.Quantity).GreaterThan(0);
    }
}