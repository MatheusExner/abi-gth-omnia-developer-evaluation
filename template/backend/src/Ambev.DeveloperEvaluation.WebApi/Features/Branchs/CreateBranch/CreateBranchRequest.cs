using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// Represents a request to create a new Branch in the system.
/// </summary>
public class CreateBranchRequest
{
    /// <summary>
    /// Gets or sets the Branchname. Must be unique and contain only valid characters.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}