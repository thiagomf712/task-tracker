namespace Domain.WorkItems.Entities.Dtos;

public record CreateWorkItemProps
{
  public required string Description { get; init; }
}

