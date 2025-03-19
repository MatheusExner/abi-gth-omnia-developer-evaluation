using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// Validator for CreateCustomerRequest that defines validation rules for Customer creation.
/// </summary>
public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCustomerRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customername: Required, length between 3 and 100 characters
    /// - CustomerPrice: Must be bigger then 0
    /// </remarks>
    public CreateCustomerRequestValidator()
    {
        RuleFor(Customer => Customer.Name).NotEmpty().Length(3, 100);
    }
}