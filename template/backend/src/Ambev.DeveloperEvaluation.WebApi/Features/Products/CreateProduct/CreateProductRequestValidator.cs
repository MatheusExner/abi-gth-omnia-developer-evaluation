using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for Product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Productname: Required, length between 3 and 100 characters
    /// - ProductPrice: Must be bigger then 0
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(Product => Product.Price).GreaterThan(0);
        RuleFor(Product => Product.Name).NotEmpty().Length(3, 100);
    }
}