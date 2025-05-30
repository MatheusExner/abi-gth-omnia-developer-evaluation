﻿using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Handler for processing CancelSaleCommand requests
/// </summary>
public class CancelSaleHandler : IRequestHandler<CancelSaleCommand>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMessagePublisher _messagePublisher;

    /// <summary>
    /// Initializes a new instance of CancelSaleHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    public CancelSaleHandler(ISaleRepository saleRepository,
    IMessagePublisher messagePublisher)
    {
        _saleRepository = saleRepository;
        _messagePublisher = messagePublisher;
    }

    /// <summary>
    /// Handles the CancelSaleCommand request
    /// </summary>
    /// <param name="command">The CancelSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Canceld Sale details</returns>
    public async Task Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(command.Id);
        if (sale == null)
            throw new InvalidOperationException($"Sale with id {command.Id} not found");

        sale.CancelSale();
        await _saleRepository.UpdateAsync(sale, cancellationToken);
        
        _messagePublisher.Publish(sale, "sale.cancelled");
    }
}
