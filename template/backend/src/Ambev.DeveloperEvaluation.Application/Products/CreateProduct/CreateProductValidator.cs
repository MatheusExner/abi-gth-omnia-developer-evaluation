using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for user creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters
    /// - Price: Required, must be bigger then 0
    /// </remarks>
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Name).NotEmpty().Length(3, 100);
        RuleFor(product => product.Price).NotEmpty().GreaterThan(0);
    }
}