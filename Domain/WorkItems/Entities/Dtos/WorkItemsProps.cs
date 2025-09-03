namespace Domain.WorkItems.Entities.Dtos;

public record WorkItemsProps
{
  public required int Id { get; init; }
  public required string Description { get; init; }
  public required WorkItemStatus Status { get; init; }
  public required DateTime CreatedAt { get; init; }
  public required DateTime UpdatedAt { get; init; }
}