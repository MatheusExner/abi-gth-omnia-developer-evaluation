﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMessagePublisher _messagePublisher;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public CreateSaleHandler(ISaleRepository saleRepository,
    ICustomerRepository customerRepository,
    IBranchRepository branchRepository,
    ISaleItemRepository saleItemRepository,
    IMessagePublisher messagePublisher,
     IMapper mapper)
    {
        _saleRepository = saleRepository;
        _customerRepository = customerRepository;
        _branchRepository = branchRepository;
        _saleItemRepository = saleItemRepository;
        _messagePublisher = messagePublisher;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer == null)
            throw new InvalidOperationException($"Customer with id {command.CustomerId} not found");

        var branch = await _branchRepository.GetByIdAsync(command.BranchId, cancellationToken);
        if (branch == null)
            throw new InvalidOperationException($"Branch with id {command.BranchId} not found");

        var saleItems = new List<SaleItem>();
        foreach (var saleItemId in command.SaleItemsIds)
        {
            var saleItem = await _saleItemRepository.GetByIdAsync(saleItemId, cancellationToken);
            if (saleItem == null)
                throw new InvalidOperationException($"Sale Item with id {saleItemId} not found");
            saleItems.Add(saleItem);
        }

        var sale = _mapper.Map<Sale>(command);

        sale.Branch = branch;
        sale.Customer = customer;
        sale.Items = saleItems;

        var createdSale = await _saleRepository.AddAsync(sale, cancellationToken);

        _messagePublisher.Publish(createdSale, "sales.created");

        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
