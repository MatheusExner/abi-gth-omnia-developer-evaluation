using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItems;

/// <summary>
/// Profile for mapping between Sale entity and CreateSaleItemResponse
/// </summary>
public class CreateSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleItem operation
    /// </summary>
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, CreateSaleItemResult>();
    }
}
