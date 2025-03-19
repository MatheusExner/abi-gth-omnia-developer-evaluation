using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Command for update an existing product.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a product's name
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateProductResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateProductCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    /// <summary>
    /// The produt Id to be updated.
    /// </summary>
    public Guid Id { get; set; } 

    /// <summary>
    /// Gets or sets the product name of the product to be updated.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price for the product.
    /// </summary>
    public decimal Price { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}