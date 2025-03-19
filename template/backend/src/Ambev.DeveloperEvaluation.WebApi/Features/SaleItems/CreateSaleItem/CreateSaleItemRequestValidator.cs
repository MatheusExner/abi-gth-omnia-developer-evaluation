using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemRequest that defines validation rules for SaleItem creation.
/// </summary>
public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - BranchId: crequired
    /// - CustomerId: required
    /// </remarks>
    public CreateSaleItemRequestValidator()
    {
        RuleFor(SaleItem => SaleItem.ProductId).NotEmpty();
        RuleFor(SaleItem => SaleItem.Quantity).GreaterThan(0);
    }
}