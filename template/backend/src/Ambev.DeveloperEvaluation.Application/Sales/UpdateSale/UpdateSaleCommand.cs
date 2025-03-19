using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for update an existing Sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a Sale's name
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    /// <summary>
    /// The Id of the sale { get; set; }
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The customer Id of the sale.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The branch Id of the sale.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// The sale items Ids of the sale.
    /// </summary>
    public List<Guid> SaleItemsIds { get; set; } = [];

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}