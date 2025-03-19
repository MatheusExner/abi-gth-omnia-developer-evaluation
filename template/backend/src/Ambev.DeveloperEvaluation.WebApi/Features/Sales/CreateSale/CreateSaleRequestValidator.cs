using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - BranchId: crequired
    /// - CustomerId: required
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(Sale => Sale.BranchId).NotEmpty();
        RuleFor(Sale => Sale.CustomerId).NotEmpty();
    }
}