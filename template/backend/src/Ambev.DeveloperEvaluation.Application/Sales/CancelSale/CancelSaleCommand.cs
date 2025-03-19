using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Command for Cancel an existing Sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a Sale's name
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// 
/// The data provided in this command is validated using the 
/// <see cref="CancelSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CancelSaleCommand : IRequest
{
    public CancelSaleCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}