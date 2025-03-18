using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// Validator for CreateBranchRequest that defines validation rules for Branch creation.
/// </summary>
public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateBranchRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Branchname: Required, length between 3 and 100 characters
    /// - BranchPrice: Must be bigger then 0
    /// </remarks>
    public CreateBranchRequestValidator()
    {
        RuleFor(Branch => Branch.Name).NotEmpty().Length(3, 100);
    }
}