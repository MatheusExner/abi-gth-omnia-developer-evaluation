using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItems;

/// <summary>
/// Handler for processing CreateSaleItemCommand requests
/// </summary>
public class CreateSaleItemHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleItemHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleItemCommand</param>
    public CreateSaleItemHandler(ISaleItemRepository saleRepository, 
        IProductRepository productRepository,
        IMapper mapper)
    {
        _saleItemRepository = saleRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleItemCommand request
    /// </summary>
    /// <param name="command">The CreateSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale details</returns>
    public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(command.ProductId, cancellationToken);
        
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {command.ProductId} not found");

        var saleItem = _mapper.Map<SaleItem>(command);

        saleItem.Product = product;
        saleItem.UnitPrice = product.Price;
        saleItem.ApplyDiscount();

        var createdSale = await _saleItemRepository.AddAsync(saleItem, cancellationToken);

        var result = _mapper.Map<CreateSaleItemResult>(createdSale);

        return result;
    }
}
