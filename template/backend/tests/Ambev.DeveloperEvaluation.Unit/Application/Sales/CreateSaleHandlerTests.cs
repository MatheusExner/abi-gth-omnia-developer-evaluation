using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _customerRepository = Substitute.For<ICustomerRepository>();
        _branchRepository = Substitute.For<IBranchRepository>();
        _saleItemRepository = Substitute.For<ISaleItemRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _customerRepository, _branchRepository, _saleItemRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid Sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Sale data When creating Sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Branch = new Branch { Id = command.BranchId },
            Customer = new Customer { Id = command.CustomerId },
            Items = command.SaleItemsIds.Select(id => new SaleItem { Id = id }).ToList()
        };

        var customer = new Customer
        {
            Id = command.CustomerId,
            Name = "Customer mock"
        };

        var branch = new Branch
        {
            Id = command.BranchId,
            Name = "Branch mock"
        };

        var saleItems = command
            .SaleItemsIds
            .Select(x => new SaleItem
            {
                Id = x,
                Quantity = 1,
                UnitPrice = 10,
                Product = new Product { Id = Guid.NewGuid(), Name = "Product mock", Price = 10 }
            })
            .ToList();

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            Branch = branch,
            Customer = customer,
            Items = saleItems
        };


        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        _branchRepository.GetByIdAsync(command.BranchId, Arg.Any<CancellationToken>())
            .Returns(branch);

        _customerRepository.GetByIdAsync(command.CustomerId, Arg.Any<CancellationToken>())
            .Returns(customer);

        _saleItemRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(ci => saleItems.Find(si => si.Id == ci.Arg<Guid>()));

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());

        _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
            c.BranchId == command.BranchId &&
            c.CustomerId == command.CustomerId &&
            c.SaleItemsIds == command.SaleItemsIds));
    }

    /// <summary>
    /// Tests that an invalid branch Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid branch Id When creating Sale Then throws validation exception")]
    public async Task Handle_ValidRequest_ThrowsValidationBranchException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Branch = new Branch { Id = command.BranchId },
            Customer = new Customer { Id = command.CustomerId },
            Items = command.SaleItemsIds.Select(id => new SaleItem { Id = id }).ToList()
        };

        var customer = new Customer
        {
            Id = command.CustomerId,
            Name = "Customer mock"
        };

        var saleItems = command
            .SaleItemsIds
            .Select(x => new SaleItem
            {
                Id = x,
                Quantity = 1,
                UnitPrice = 10,
                Product = new Product { Id = Guid.NewGuid(), Name = "Product mock", Price = 10 }
            })
            .ToList();

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            Branch = null,
            Customer = customer,
            Items = saleItems
        };


        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        _branchRepository.GetByIdAsync(command.BranchId, Arg.Any<CancellationToken>())
            .Returns(null as Branch);

        _customerRepository.GetByIdAsync(command.CustomerId, Arg.Any<CancellationToken>())
            .Returns(customer);

        _saleItemRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(ci => saleItems.Find(si => si.Id == ci.Arg<Guid>()));

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage($"Branch with id {command.BranchId} not found");
    }

    /// <summary>
    /// Tests that an invalid customer Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid customer Id When creating Sale Then throws validation exception")]
    public async Task Handle_ValidRequest_ThrowsValidationCustomerException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Branch = new Branch { Id = command.BranchId },
            Customer = new Customer { Id = command.CustomerId },
            Items = command.SaleItemsIds.Select(id => new SaleItem { Id = id }).ToList()
        };


        var branch = new Branch
        {
            Id = command.BranchId,
            Name = "Branch mock"
        };

        var saleItems = command
            .SaleItemsIds
            .Select(x => new SaleItem
            {
                Id = x,
                Quantity = 1,
                UnitPrice = 10,
                Product = new Product { Id = Guid.NewGuid(), Name = "Product mock", Price = 10 }
            })
            .ToList();

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            Branch = branch,
            Customer = null,
            Items = saleItems
        };


        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        _branchRepository.GetByIdAsync(command.BranchId, Arg.Any<CancellationToken>())
            .Returns(branch);

        _customerRepository.GetByIdAsync(command.CustomerId, Arg.Any<CancellationToken>())
            .Returns(null as Customer);

        _saleItemRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(ci => saleItems.Find(si => si.Id == ci.Arg<Guid>()));

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage($"Customer with id {command.CustomerId} not found");
    }

    /// <summary>
    /// Tests that an invalid SaleItem Id request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid SaleItem Id When creating Sale Then throws validation exception")]
    public async Task Handle_ValidRequest_ThrowsValidationSaleItemException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Branch = new Branch { Id = command.BranchId },
            Customer = new Customer { Id = command.CustomerId },
            Items = command.SaleItemsIds.Select(id => new SaleItem { Id = id }).ToList()
        };

        var customer = new Customer
        {
            Id = command.CustomerId,
            Name = "Customer mock"
        };

        var branch = new Branch
        {
            Id = command.BranchId,
            Name = "Branch mock"
        };


        var result = new CreateSaleResult
        {
            Id = sale.Id,
            Branch = branch,
            Customer = customer,
            Items = []
        };


        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        _branchRepository.GetByIdAsync(command.BranchId, Arg.Any<CancellationToken>())
            .Returns(branch);

        _customerRepository.GetByIdAsync(command.CustomerId, Arg.Any<CancellationToken>())
            .Returns(customer);

        _saleItemRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(null as SaleItem);

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage($"Sale Item with id {command.SaleItemsIds.First()} not found");
    }

    /// <summary>
    /// Tests that an invalid Sale creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid Sale data When creating Sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }
}
