using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductRequest that defines validation rules for Product creation.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Productname: Required, length between 3 and 100 characters
    /// - ProductPrice: Must be bigger then 0
    /// </remarks>
    public UpdateProductRequestValidator()
    {
        RuleFor(Product => Product.Price).GreaterThan(0);
        RuleFor(Product => Product.Name).NotEmpty().Length(3, 100);
    }
}