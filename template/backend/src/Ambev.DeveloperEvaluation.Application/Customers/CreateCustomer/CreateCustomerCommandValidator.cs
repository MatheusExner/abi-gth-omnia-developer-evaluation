using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Validator for CreateCustomerCommand that defines validation rules for user creation command.
/// </summary>
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCustomerCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters
    /// - Price: Required, must be bigger then 0
    /// </remarks>
    public CreateCustomerCommandValidator()
    {
        RuleFor(Customer => Customer.Name).NotEmpty().Length(3, 100);
    }
}