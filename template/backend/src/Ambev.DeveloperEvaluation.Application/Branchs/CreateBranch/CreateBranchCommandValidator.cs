using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Validator for CreateBranchCommand that defines validation rules for user creation command.
/// </summary>
public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateBranchCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters
    /// - Price: Required, must be bigger then 0
    /// </remarks>
    public CreateBranchCommandValidator()
    {
        RuleFor(Branch => Branch.Name).NotEmpty().Length(3, 100);
    }
}