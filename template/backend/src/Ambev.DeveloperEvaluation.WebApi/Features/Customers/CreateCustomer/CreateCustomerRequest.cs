using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// Represents a request to create a new Customer in the system.
/// </summary>
public class CreateCustomerRequest
{
    /// <summary>
    /// Gets or sets the Customername. Must be unique and contain only valid characters.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}