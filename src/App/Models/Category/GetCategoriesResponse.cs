namespace App.Models.Category
{
	public record GetCategoriesResponse
		(Guid Id,
		string Title,
		bool IsApprovalNeeded);
}
