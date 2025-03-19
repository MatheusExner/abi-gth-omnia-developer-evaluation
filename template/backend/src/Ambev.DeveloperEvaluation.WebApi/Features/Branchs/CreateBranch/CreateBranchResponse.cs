namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// API response model for CreateBranch operation
/// </summary>
public class CreateBranchResponse
{
    /// <summary>
    /// The unique identifier of the created Branch
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Branch's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;


}
