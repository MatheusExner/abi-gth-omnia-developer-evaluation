using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleCommand that defines validation rules for user creation command.
/// </summary>
public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters
    /// </remarks>
    public UpdateSaleCommandValidator()
    {
        RuleFor(Sale => Sale.BranchId).NotEmpty();
        RuleFor(Sale => Sale.CustomerId).NotEmpty();
    }
}