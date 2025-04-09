using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

/// <summary>
/// Contains unit tests for the <see cref="GetSaleHandler"/> class.
/// </summary>
public class GetSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly GetSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleHandlerTests"/> class.
    /// Sets up the test dependencies and Gets fake data generators.
    /// </summary>
    public GetSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new GetSaleHandler(_saleRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Sale data When creating Sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = new GetSaleCommand(Guid.NewGuid());

        var branch = new Branch { Id = Guid.NewGuid(), Name = "Fake Branch" };
        var customer = new Customer { Id = Guid.NewGuid(), Name = "Fake Customer" };
        var items = new List<SaleItem>(){
                new ()
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    UnitPrice = 10,
                    Product = new Product { Id = Guid.NewGuid(), Name = "Product mock", Price = 10 }
                }
            };
        var sale = new Sale
        {
            Id = command.Id,
            Branch = branch,
            Customer = customer,
            Items = items
        };

        _saleRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        var result = new GetSaleResult
        {
            Id = sale.Id,
            Branch = branch,
            Customer = customer,
            Items = items
        };

        _mapper.Map<GetSaleResult>(sale).Returns(result);

        // When
        var GetSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        GetSaleResult.Should().NotBeNull();
        GetSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());

        _mapper.Received(1).Map<GetSaleResult>(Arg.Is<Sale>(c =>
            c.Id == sale.Id &&
            c.Items == sale.Items &&
            c.Branch == sale.Branch &&
            c.Customer == sale.Customer
        ));
    }

    /// <summary>
    /// Tests that an invalid sale Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale Id When getting a Sale Then throws validation exception")]
    public async Task Handle_ValidRequest_ThrowsValidationSaleException()
    {
        // Given
        var command = new GetSaleCommand(Guid.NewGuid());

        _saleRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(null as Sale);

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"Sale with id {command.Id} not found");
    }

}
