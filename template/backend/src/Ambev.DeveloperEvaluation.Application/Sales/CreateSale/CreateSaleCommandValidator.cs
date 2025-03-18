using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for user creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - BranchId: Requireds
    /// - CustomerId: Required
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(Sale => Sale.BranchId).NotEmpty();
        RuleFor(Sale => Sale.CustomerId).NotEmpty();
    }
}