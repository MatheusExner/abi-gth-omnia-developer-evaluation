using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductCommand that defines validation rules for user creation command.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters
    /// </remarks>
    public UpdateProductCommandValidator()
    {
        RuleFor(product => product.Name).NotEmpty().Length(3, 100);
        RuleFor(product => product.Price).NotEmpty().GreaterThan(0);
    }
}